using IDP.Application.Command.Auth;
using IDP.Domain.IRepository.Command.Base;
using MediatR;

namespace IDP.Application.Handller.Command.Auth
{
    public class AuthCommandHandler : IRequestHandler<AuthCommand, bool>
    {
        private readonly IOtpRedisRepository _otpRedisRepository;
        public AuthCommandHandler(IOtpRedisRepository otpRedisRepository)
        {
            _otpRedisRepository = otpRedisRepository;
        }
        public async Task<bool> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            _otpRedisRepository.Insert(new Domain.DTO.Otp { UserId = 230, OptCode = "45668", IsUse = false});
            return true;
        }
    }
}
