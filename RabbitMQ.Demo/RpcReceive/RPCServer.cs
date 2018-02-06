using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

public class RPCServer
{
    public void rpcServer()
    {

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
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "koofang.RealtyIntroduce.details", durable: false, exclusive: false, autoDelete: false, arguments: null);

            channel.BasicQos(0, 1, false);
            var consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume(queue: "koofang.RealtyIntroduce.details", autoAck: false, consumer: consumer);


            // Console.WriteLine(" [x] Awaiting RPC requests");

            consumer.Received += (model, ea) =>
            {
                string response = null;

                var body = ea.Body;
                var props = ea.BasicProperties;
                var replyProps = channel.CreateBasicProperties();
                replyProps.CorrelationId = props.CorrelationId;

                try
                {
                    var message = Encoding.UTF8.GetString(body);
                    // Console.WriteLine("收到消息 ({0})", message);
                    // log==================log 收到消息
                    response = message + "_" + DateTime.Now.ToString();
                }
                catch (Exception e)
                {
                    // Console.WriteLine(" 出错了： " + e.Message);
                    // log==================log
                    response = "";
                }
                finally
                {
                    var responseBytes = Encoding.UTF8.GetBytes(response);
                    channel.BasicPublish(exchange: "", routingKey: props.ReplyTo, basicProperties: replyProps, body: responseBytes);
                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                }
            };

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
