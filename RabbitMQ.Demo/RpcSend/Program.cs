using RabbitMQ.Client;
using System;
using System.Text;

namespace ProjectSend
{
    class Program
    {
        static void Main(string[] args)
        {
            var rpcClient = new RPCClient();

            var entity =new ProjectSend.RealtyIntroduce();
            entity.AreaCode = "B024";
            entity.RealtyId = 945;


           var outputMsg =Newtonsoft.Json.JsonConvert.SerializeObject(entity);

            var inputMsg = rpcClient.Call(outputMsg, "koofang.RealtyIntroduce.details", "details");

            Console.WriteLine(inputMsg);
            rpcClient.Close();


            rpcClient = new RPCClient();
            var inputEntity= Newtonsoft.Json.JsonConvert.DeserializeObject<ProjectSend.RealtyIntroduce>(inputMsg);
            if (inputEntity.RentRealtyIntroduceData != null)
            {
                inputEntity.RentRealtyIntroduceData.RealtyTitle = "aaaaaaaaaaaaa";
                inputEntity.RentRealtyIntroduceData.RentPoint = "aaaaaaaa";
            }
            if (inputEntity.SaleRealtyIntroduceData != null)
            {
                inputEntity.SaleRealtyIntroduceData.RealtyTitle = "aaaaaaaaaaaa";
            }

            outputMsg = Newtonsoft.Json.JsonConvert.SerializeObject(inputEntity);

            inputMsg = rpcClient.Call(outputMsg, "koofang.RealtyIntroduce.modify", "modify");
            Console.WriteLine(inputMsg);

            Console.ReadLine();
            rpcClient.Close();

        }
    }
}