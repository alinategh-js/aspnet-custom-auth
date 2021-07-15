using Auth.Api.Models;
using Auth.Domain.Entity;
using Auth.Domain.Utils;
using Auth.Service.Interface;
using Auth.Service.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Service.Implement
{
    public class UserService : IUserService
    {
        private readonly List<User> _usersList;
        public UserService()
        {
            _usersList = new List<User>
            {
                new User{ UserId=1, Firstname="Ali", Lastname="Nategh", Username="alinategh", Password="iamali!"},
                new User{ UserId=2, Firstname="John", Lastname="Doe", Username="johndoe", Password="iamjohn!"},
                new User{ UserId=3, Firstname="Bob", Lastname="King", Username="bobking", Password="iambob!"},
                new User{ UserId=4, Firstname="Lisa", Lastname="Knight", Username="lisaknight", Password="iamlisa!"}
            };
        }

        public async Task<ResponseModel<User>> Login(SignInModel model)
        {
            var response = new ResponseModel<User>();

            try
            {
                var foundUser = _usersList.FirstOrDefault(user => user.Username == model.Username && user.Password == model.Password);

                if (foundUser != null)
                {
                    response.IsSuccessful = true;
                    response.Result = foundUser;
                    response.Message = ServiceMessage.Success;
                }
                else
                {
                    response.IsSuccessful = false;
                    response.Message = ServiceMessage.UsernameOrPasswordIsWrong;
                }

                return response;

            }
            catch (Exception e)
            {
                response.IsSuccessful = false;
                response.Message = ServiceMessage.SomethingWentWrong;

                return response;
            }
        }
    }
}
