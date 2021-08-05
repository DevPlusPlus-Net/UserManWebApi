using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UMDTO;
using UMUserContracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManWebApi.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        IUserService _userService; 
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
       
        [HttpPost]
        public UserResponse RegisterUser([FromBody] UserDTO user)
        {
            
            var retval = _userService.RegisterUser(user);
            return retval; 
        }

        [HttpPost]
        public UserResponse Login([FromBody] UserDTO user)
        {
            var retval =  _userService.Login(user);
            return retval;
        }




    }
}
