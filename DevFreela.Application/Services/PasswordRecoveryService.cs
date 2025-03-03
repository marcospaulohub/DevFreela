using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using DevFreela.Application.Models;
using DevFreela.Core.Messages.UserMessages;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Auth;
using DevFreela.Infrastructure.Notifications;

namespace DevFreela.Application.Services
{
    public class PasswordRecoveryService: IPasswordRecoveryService
    {
        private readonly IUserRepository _repository;
        private readonly IMemoryCache _cache;
        private readonly IEmailService _emailService;
        private readonly IAuthService _authService;
        private const double EXPIRATION_TIME = 10;

        public PasswordRecoveryService(IUserRepository repository, IMemoryCache cache, IEmailService emailService, IAuthService authService)
        {
            _repository = repository;
            _cache = cache;
            _emailService = emailService;
            _authService = authService;
        }
        public async Task<ResultViewModel> RequestPasswordRecovery(PasswordRecoveryRequestInputModel model)
        {
            var user = await _repository.GetByEmail(model.Email);

            if (user is null)
            {
                return ResultViewModel.Error(UserMsgs.GetUserRequestPasswordRecoveryError());
            }

            var code = new Random().Next(100000, 999999).ToString();

            var cacheKey = $"RecoveryCode:{user.Email}";

            _cache.Set(cacheKey, code, TimeSpan.FromMinutes(EXPIRATION_TIME));

            var subject = UserMsgs.GetUserRequestPasswordRecoverySubject();
            var message = UserMsgs.GetUserRequestPasswordRecoveryMessage() + code;

            await _emailService.SendAsync(model.Email, subject, message);

            return ResultViewModel.Success();
        }
        public ResultViewModel ValidateRecoveryCode(ValidateRecoveryCodeInputModel model)
        {
            var cacheKey = $"RecoveryCode:{model.Email}";

            if(!_cache.TryGetValue(cacheKey, out string? code) || code != model.Code)
            {
                return ResultViewModel.Error(UserMsgs.GetUserValidateRecoveryCodeError());
            }

            return ResultViewModel.Success();
        }
        public async Task<ResultViewModel> ChangePassword(ChangePasswordInputModel model)
        {
            var cacheKey = $"RecoveryCode:{model.Email}";

            if (!_cache.TryGetValue(cacheKey, out string? code) || code != model.Code)
            {
                return ResultViewModel.Error(UserMsgs.GetUserChangePasswordError());
            }

            _cache.Remove(cacheKey);

            var user = await _repository.GetByEmail(model.Email);

            if (user is null)
            {
                return ResultViewModel.Error(UserMsgs.GetUserChangePasswordError());
            }

            var hash = _authService.ComputeHash(model.NewPassword);

            user.UpdatePassword(hash);
            await _repository.Update(user);

            return ResultViewModel.Success();
        }

    }
}
