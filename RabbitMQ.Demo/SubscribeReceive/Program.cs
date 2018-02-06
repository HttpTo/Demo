using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Receivedo
{
    public class Mq{
        public static void Main()
        {
            new  XxxMqReceive().Rece(10);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }

    class XxxMqReceive
    {
        private static IConnection connection;
        private static List<IModel> channels=new List<IModel>();

        public XxxMqReceive()
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://domain_user:Pa$$w0rd@mqtest.domain.com:5672/xxxx");
            connection = factory.CreateConnection();
        }

        public void Rece(int channelCount)
        {
            var exchaneTopOff = "TipOffChange";
            var queueTopOff = "domain.TipOffChange.add";

            for (int i = 0; i < channelCount; i++)
            {
                var channel = connection.CreateModel();
                //4. 申明队列
                channel.ExchangeDeclare(exchaneTopOff, ExchangeType.Topic, true, false, null);
                channel.QueueDeclare(queueTopOff, durable: true, exclusive: false, autoDelete: false, arguments: null);
                channel.QueueBind(queueTopOff, exchaneTopOff, "add", null);
                //5. 构造消费者实例
                var consumer = new EventingBasicConsumer(channel);
                //6. 绑定消息接收后的事件委托
                consumer.Received += (model, ea) =>
                {
                    var message = Encoding.UTF8.GetString(ea.Body);
                    Console.WriteLine($" [channel][{i}] Received {message}");
                };
                //7. 启动消费者
                channel.BasicConsume(queue: queueTopOff, autoAck: true, consumer: consumer);
                channels.Add(channel);
            }

        }

        public void Close()
        {
            foreach (var channel in channels)
            {
                channel.Close(200, "Goodbye!");
            }
            connection.Close();
        }


    }
}