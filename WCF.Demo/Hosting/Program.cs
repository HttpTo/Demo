using System;

using System.ServiceModel;
using System.ServiceModel.Description;

using Artech.WcfServices.Contracts;
using Artech.WcfServices.Services;

namespace Artech.WcfServices.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            MainCfg(args);
        }

        /// <summary>
        ///  通过配置文件启动服务
        /// </summary>
        /// <param name="args"></param>
        static void MainCfg(string[] args)
        {
            // WCF配置编辑器:VS的工具（Tools）--> 选择“WCF Service Configuration Editor”
            /*
             <?xml version="1.0" encoding="utf-8" ?>
            <configuration>
                <system.serviceModel>
                    <behaviors>
                        <serviceBehaviors>
                            <behavior name="metadataBehavior">
                                <serviceMetadata httpGetEnabled="true" httpGetUrl="http://127.0.0.1:9999/calculatorservice/metadata" />
                            </behavior>
                        </serviceBehaviors>
                    </behaviors>
                    <services>
                        <service behaviorConfiguration="metadataBehavior" name="Artech.WcfServices.Services.CalculatorService">
                            <endpoint address="http://127.0.0.1:9999/calculatorservice" binding="wsHttpBinding" contract="Artech.WcfServices.Contracts.ICalculator" />
                        </service>
                    </services>
                </system.serviceModel>
            </configuration>
            */

            using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
                host.Opened += delegate
                {
                    Console.WriteLine("CalculaorService已经启动，按任意键终止服务！");
                };
                host.Open();
                Console.Read();
            }
        }

        /// <summary>
        /// 通过代码启动服务
        /// </summary>
        /// <param name="args"></param>
        static void MainDel(string[] args)
        {
            // ServiceHost
            // 1.通过WCF的typeof(typeof(CalculatorService))创建ServieHost对象
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
                // 2.1.终结点地址http://127.0.0.1:9999/calculatorservice
                // 2.2.WSHttpBinding
                // 2.3.服务契约类型:ICalculator。
                host.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "http://127.0.0.1:9999/calculatorservice");

                // 3.1.WCF服务的描述通过元数据（Metadata）的形式发布出来。
                // 3.2.WCF中元数据的发布通过一个特殊的服务行为ServiceMetadataBehavior实现。
                // 3.3.为创建的ServiceHost添加了ServiceMetadataBehavior
                if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                {
                    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                    // 3.4.基于HTTP - GET的元数据获取方式
                    behavior.HttpGetEnabled = true;
                    // 3.5.元数据的发布地址通过ServiceMetadataBehavior的HttpGetUrl指定。
                    behavior.HttpGetUrl = new Uri("http://127.0.0.1:9999/calculatorservice/metadata");
                    host.Description.Behaviors.Add(behavior);
                }
                host.Opened += delegate
                {
                    Console.WriteLine("CalculaorService已经启动，按任意键终止服务！");
                };
                // 3.6.ServiceHost的Open方法对服务寄宿
                host.Open();
                // 3.7.可以通http://127.0.0.1:9999/calculatorservice/metadata获取服务相关的WSDL形式体现的服务元数据
                Console.WriteLine("http://127.0.0.1:9999/calculatorservice/metadata");
                Console.Read();
            }
        }
    }
}