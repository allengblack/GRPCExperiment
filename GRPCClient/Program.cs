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

            var res = client.GetUser(new UserRequest { Id = "dsafsdsfd" });
            Console.WriteLine($"{res.User.Id} {res.User.Name}");

            var res2 = client.GetUsers(new Empty());
            Console.WriteLine($"{res2.Users[0].Id} {res2.Users[0].Name}");
            Console.WriteLine($"{res2.Users[1].Id} {res2.Users[1].Name}");

            Console.ReadKey();
        }
    }
}
