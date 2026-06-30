using CyberSecurite.Api.Dtos;
using CyberSecurite.Api.Infrastructure;
using CyberSecurite.Domain.Commands;
using CyberSecurite.Domain.Entities;
using CyberSecurite.Domain.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tools.Cqs.Commands;
using Tools.Cqs.Queries;

namespace CyberSecurite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ICommandHandler<RegisterCommand> registerCommandHandler, IQueryHandler<LoginQuery, Utilisateur> loginQueryHandler) : ControllerBase
    {
        private readonly ICommandHandler<RegisterCommand> _registerCommandHandler = registerCommandHandler;
        private readonly IQueryHandler<LoginQuery, Utilisateur> _loginQueryHandler = loginQueryHandler;

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            return this.FromResult(_registerCommandHandler.Execute(new RegisterCommand(dto.Nom, dto.Prenom, dto.Email, dto.Password)));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            return this.FromResult(_loginQueryHandler.Execute(new LoginQuery(dto.Email, dto.Password)));
        }
    }
}
