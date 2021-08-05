using System;
using UMDal;
using UMDTO;
using UMUserContracts;

namespace UserServiceImpl
{
    public class UserService : IUserService
    {
        IUserDAL _dal;
        public UserService(IUserDAL dal)
        {
            _dal = dal;
        }
        public UserResponse Login(UserDTO user)
        {
            var retval = new UserResponse();
            retval.Message = "UserNotExists"; 
            var ds = _dal.GetUser(user); 
            if (ds.Tables[0].Rows.Count > 0)
            {
                retval.Message = "OK";
                retval.User = user;
            }
            return retval;
        }

        public UserResponse RegisterUser(UserDTO user)
        {
            var retval = new UserResponse();
            retval.Message = "UserExists";
            retval.User = null; 
            var ds = _dal.GetUser(user);
            if (ds.Tables[0].Rows.Count == 0)
            {
                var ds2 = _dal.AddUser(user);
                retval.Message = "OK";
                retval.User = user;
                
            }
            
            return retval; 


        }
    }
}
