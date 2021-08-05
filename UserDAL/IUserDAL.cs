using System;
using System.Data;
using UMDTO;

namespace UMDal

{
    public interface IUserDAL
    {
        DataSet AddUser(UserDTO user);
        DataSet GetUser(UserDTO user);

    }
}
