using Auth;
using IDP.Application.Query.Auth;
using MediatR;

namespace IDP.Application.Handller.Query
{
    public class AuthHandler : IRequestHandler<AuthQuery, bool>
    {
        private readonly IJwtHandler _jwtHandler;
        public AuthHandler(IJwtHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
        }
        public async Task<bool> Handle(AuthQuery request, CancellationToken cancellationToken)
        {
            var token = _jwtHandler.Create(34);
            return true;
        }
    }
}
