using DevFreela.Application.Models;
using System.Threading.Tasks;

namespace DevFreela.Application.Services
{
    public interface IPasswordRecoveryService
    {
        Task<ResultViewModel> RequestPasswordRecovery(PasswordRecoveryRequestInputModel model);

        ResultViewModel ValidateRecoveryCode(ValidateRecoveryCodeInputModel model);

        Task<ResultViewModel> ChangePassword(ChangePasswordInputModel model);
    }
}
