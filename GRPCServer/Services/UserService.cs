using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GRPCServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GRPCExperiment.Services
{
    public class UserService : GRPCExperiment.Users.UsersBase
    {
        private readonly UsersContext _dataContext;

        public UserService(UsersContext dataContext)
        {
            _dataContext = dataContext;
        }

        public override Task<UserResponse> GetUser(UserRequest request, ServerCallContext context)
        {
            return Task.FromResult(new UserResponse { User = new User { Name = "Gbolahan Allen", Id = Guid.NewGuid().ToString() } });
        }

        public async override Task<UsersResponse> GetUsers(Empty request, ServerCallContext context)
        {
            //var users = await _dataContext.Users.ToListAsync();
            var users = (from u in _dataContext.Users
                         select u).ToList();

            return new UsersResponse { Users = { users.Select(u => new User { Id = u.Id.ToString(), Name = u.Name})} };


            //return new UsersResponse { Users = { users.Select(u => new User { Name = u.Name, Id = u.Id.ToString() }) } };
        }
    }
}