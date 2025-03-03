using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using DevFreela.Application.Commands.Users.InsertUser;
using DevFreela.Application.Commands.Users.InsertUserSkill;
using DevFreela.Application.Queries.Users.GetUserById;
using DevFreela.Application.Queries.Users.Login;
using DevFreela.Application.Models;
using DevFreela.Application.Services;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPasswordRecoveryService _passwordRecoveryService;

        public UsersController(IMediator mediator, IPasswordRecoveryService passwordRecoveryService)
        {
            _mediator = mediator;
            _passwordRecoveryService = passwordRecoveryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            var result = await _mediator.Send(new LoginQuery(model.Email, model.Password));

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("{id}/skills")]
        public async Task<IActionResult> PostSkills(int id, InsertUserSkillCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpPut("{id}/profile-picture")]
        public IActionResult PostProfilePicture(int id, IFormFile file)
        {
            var description = $"File: {file.FileName}, Size: {file.Length}";

            //Processar a imagem.
            // Salvar no banco de dados ou salvar local ou salvar no S3 AWS, etc.

            return Ok(description);
        }

        [AllowAnonymous]
        [HttpPost("password-recovery/request")]
        public async Task<IActionResult> RequestPasswordRecovery(PasswordRecoveryRequestInputModel model)
        {
            var result = await _passwordRecoveryService.RequestPasswordRecovery(model);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("password-recovery/validate")]
        public async Task<IActionResult> ValidateRecoveryCode(ValidateRecoveryCodeInputModel model)
        {
            var result = _passwordRecoveryService.ValidateRecoveryCode(model);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("password-recovery/change")]
        public async Task<IActionResult> ChangePassword(ChangePasswordInputModel model)
        {
            var result = await _passwordRecoveryService.ChangePassword(model);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
