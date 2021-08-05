using System;
using System.Collections.Generic;
using System.Text;

namespace UMDTO
{
    public class UserResponse
    {
        public string Message { get; set; }
        public UserDTO User { get; set; }
    }
}
