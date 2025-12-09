using IDP.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Domain.IRepository.Command.Base
{
    public interface IOtpRedisRepository : ICommandRepository<Otp>
    {
        Task<Otp> Getdata(string mobile);
    }
}
