﻿using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Send
{
    class Program
    {
       public static void Main(string[] args)
        {
            //amqp://sis_user:Pa$$w0rd@mqtest.koofang.com:5672/SIS

            //1.1.实例化连接工厂
            // var factory = new ConnectionFactory() { HostName = "localhost" };
            // // "guest"/"guest" by default, limited to localhost connections
            // factory.UserName = user;
            // factory.Password = pass;
            // factory.VirtualHost = vhost;
            // factory.HostName = hostName;
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://sis_user:Pa$$w0rd@mqtest.koofang.com:5672/SIS") ;


            //2. 建立连接
            using (var connection = factory.CreateConnection())
            {
                //3. 创建信道
                using (var channel = connection.CreateModel())
                {
                    //4. 申明队列
                    channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    //5. 构建byte消息数据包
                    string message = args.Length > 0 ? args[0] : "Hello RabbitMQ!";
                    var body = Encoding.UTF8.GetBytes(message);
                    //6. 发送数据包
                    channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }
        }
    }
}