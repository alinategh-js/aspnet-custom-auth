using Auth.Api.Models;
using Auth.Domain.Entity;
using Auth.Domain.Utils;
using System.Threading.Tasks;

namespace Auth.Service.Interface
{
    public interface IUserService
    {
        Task<IResponseModel<User>> Login(SignInRequest signInModel);
    }
}
