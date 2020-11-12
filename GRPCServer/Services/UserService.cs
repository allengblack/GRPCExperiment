using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRPCExperiment.Services
{
    public class UserService : GRPCExperiment.Users.UsersBase
    {
        public override Task<UserResponse> GetUser(UserRequest request, ServerCallContext context)
        {
            return Task.FromResult(new UserResponse { User = new User { Name = "Gbolahan Allen", Id = Guid.NewGuid().ToString() } });
        }

        public override Task<UsersResponse> GetUsers(Empty request, ServerCallContext context)
        {
            return Task.FromResult(new UsersResponse
            {
                Users = {
                    new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Michael Ikechi"
                    },
                    new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Olanike Usman"
                    }
                }
            });
        }
    }
}