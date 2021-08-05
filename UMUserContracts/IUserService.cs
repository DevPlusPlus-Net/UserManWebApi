using System;
using UMDTO;

namespace UMUserContracts
{
    public interface IUserService
    {
        public UserResponse RegisterUser(UserDTO user);
        public UserResponse Login(UserDTO user);

    }
}
