using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectReceive
{
    class Class1
    {

        public void aaa() {


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

            // http://blog.csdn.net/whycold/article/details/41119807
            //比如我们设置prefetchCount=1，则Queue每次给每个消费者发送一条消息；消费者处理完这条消息后Queue会再给该消费者发送一条消息。处理并发排队问题方案。
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {


                channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    // customer 顾客
                    // consumer 消费者
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "hello", autoAck: true, consumer: consumer);

                ////扔掉消息
                //channel.BasicReject(consumer.DeliveryTag, false);
                ////退回消息
                //channel.BasicReject(consumer.DeliveryTag, true);
                ////批量退回或删除,中间的参数 是否批量 true是/false否 (也就是只一条)
                //channel.BasicNack(consumer.DeliveryTag, true, true);
                //// 补发消息 true退回到queue中 / false只补发给当前的consumer
                //channel.BasicRecover(true);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

    }
}
