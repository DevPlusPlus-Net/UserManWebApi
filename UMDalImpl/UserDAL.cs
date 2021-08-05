using DalInfraContracts.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using UMDal;
using UMDTO;

namespace UMDalImpl
{
    public class UserDAL : IUserDAL
    {
        IInfraDAL _dal;
        string _strConnection;
        public UserDAL(IInfraDAL dal,IConfiguration configuration)
        {
            _dal = dal;
            _strConnection = configuration.GetConnectionString("db"); 
        }
        public DataSet AddUser(UserDTO user)
        {
            try
            {
                var connection = _dal.GetConnection(_strConnection);
                var pUserID = _dal.GetParameter("@ID", user.UserID);
                var pUserName = _dal.GetParameter("@Name", user.UserName);
                var ds = _dal.Exec(connection, "AddUser", pUserID, pUserName);
                return ds;
            }
            catch(SqlException ex)
            {
                throw (ex); 
            }

        }

        public DataSet GetUser(UserDTO user)
        {
            try
            {
                var connection = _dal.GetConnection(_strConnection);
                var pUserID = _dal.GetParameter("UserID", user.UserID);
                var ds = _dal.Exec(connection, "GetUser", pUserID);
                return ds;
            }
            catch (SqlException ex)
            {
                throw (ex);
            }

        }
    }
}
