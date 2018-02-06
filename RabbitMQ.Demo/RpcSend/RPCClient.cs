using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class RPCClient
{
    private IConnection connection;
    private IModel channel;
    private string replyQueueName;
    private QueueingBasicConsumer consumer;

    public RPCClient()
    {

        var factory = new ConnectionFactory
        {
            //uri
                         //amqp://sis_user:Pa$$w0rd@mqtest.koofang.com:5672/SIS
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


        connection = factory.CreateConnection();
        channel = connection.CreateModel();
        replyQueueName = channel.QueueDeclare().QueueName;
        consumer = new QueueingBasicConsumer(channel);
        channel.BasicConsume(queue: replyQueueName, autoAck: true, consumer: consumer);
    }

    public string Call(string message,string queue,string RoutingKey)
    {
        var corrId = Guid.NewGuid().ToString();
        var props = channel.CreateBasicProperties();
        props.ReplyTo = replyQueueName;
        props.CorrelationId = corrId;

        // binding
        channel.QueueBind(queue: queue,
                    exchange: "RealtyIntroduce",
                    routingKey: RoutingKey,
                    arguments: null);


        var messageBytes = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish(exchange: "RealtyIntroduce", routingKey: RoutingKey, basicProperties: props, body: messageBytes);

        while (true)
        {
            var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
            if (ea.BasicProperties.CorrelationId == corrId)
            {
                return Encoding.UTF8.GetString(ea.Body);
            }
        }
    }

    public void Close()
    {
        connection.Close();
    }
}
