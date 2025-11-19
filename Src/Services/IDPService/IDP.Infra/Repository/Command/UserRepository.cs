using IDP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Infra.Repository.Command
{
    public class UserRepository : IDP.Domain.IRepository.Command.IUserRepository
    {
        public async Task<bool> Insert(User user)
        {
            return true;
        }
    }
}
