using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectSend
{
    class Class1
    {
        public void send()
        {

            //var factory = new ConnectionFactory()
            //{
            //    HostName = "10.0.0.35/SIS",
            //    UserName = "sis_user",
            //    Password = "Pa$$w0rd",
            //    //端口
            //    Port = 5672,
            //    //设置心跳时间
            //    RequestedHeartbeat = 60, //config.HeartBeat,
            //    //设置自动重连
            //    AutomaticRecoveryEnabled = true, //config.AutomaticRecoveryEnabled,
            //    //重连时间
            //    NetworkRecoveryInterval = new TimeSpan(1000),// config.NetworkRecoveryInterval,
            //};

            var factory = new ConnectionFactory
            {
                //uri
                Uri = new Uri("amqp://sis_user:Pa$$w0rd@mqdev.koofang.com:5672/SIS"),
                //设置心跳时间
                RequestedHeartbeat = 10,
                //设置自动重连
                AutomaticRecoveryEnabled = true,
                //重连时间
                NetworkRecoveryInterval = new TimeSpan(0, 0, 5),
                //超时时间
                ContinuationTimeout = new TimeSpan(0, 1, 0),
                //超时重试时间
                RequestedConnectionTimeout = 30000,
                //一个链接最大channel
                RequestedChannelMax = 2000,

            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    string message = "Hello World!";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
                    Console.WriteLine(" [x] Sent {0}", message);
                }

                Console.WriteLine(" Press [enter] to exit.");
            }

            Console.ReadLine();
        }
    }
}
