using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using GRPCExperiment;
using System;

namespace GRPCClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Users.UsersClient(channel);

            var res = client.GetUsers(new Empty());

            foreach (var user in res.Users)
            {
                Console.WriteLine($" User Id: {user.Id} | User Name: {user.Name}");
            }
            Console.ReadKey();
        }
    }
}
