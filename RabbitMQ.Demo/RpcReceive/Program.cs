using System;
using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client.Events;

namespace ProjectReceive
{
    class Program
    {
        static void Main(string[] args)
        {
            new RPCServer().rpcServer();

        }
    }
}