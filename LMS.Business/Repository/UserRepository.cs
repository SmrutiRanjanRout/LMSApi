using AutoMapper;

using LMS.Model.Models;
using LMS.Model.Models.Dto;
using LMS.Business.Repository.IRepostiory;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using LMS.DataAccess;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net;
using Newtonsoft.Json.Linq;


namespace LMS.Business.Repository
{
    public class UserRepository : IUserRepository
    {
       
      
        private string secretKey;
        public static IConfiguration AppSetting;
        public UserRepository( IConfiguration configuration)
        {
            AppSetting = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
            secretKey = AppSetting.GetSection("ApiSettings")["Secret"]; 
            
        }


        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            UserDTO user =new UserDTO();
            LoginResponseDTO loginResponseDTO = new LoginResponseDTO();
            try
            {

                IDataParameter[] DParam = { };
                List<SqlParameter> lstParam = new List<SqlParameter>();
                DataAccessLayerBaseClass DataAccess = DataAccessLayerFactory.GetDataAccessLayer();
                lstParam.Add(new SqlParameter { ParameterName = "@pLoginId", SqlDbType = SqlDbType.VarChar, Size = 50, Value = loginRequestDTO.UserName });
                lstParam.Add(new SqlParameter { ParameterName = "@pPassword", SqlDbType = SqlDbType.VarChar, Size = 150, Value = loginRequestDTO.Password });
                DParam = lstParam.ToArray();
                IDataReader Result = null;
                Result = DataAccess.ExecuteDataReader("UserLogin", CommandType.StoredProcedure, DParam);
                while (Result.Read())
                {
                    user.ID = Convert.ToInt32(Result["Uid"]);
                    user.UserName = Convert.ToString(Result["LoginId"]);
                    // ObjLogin.Password = Convert.ToString(Result["Password"]);
                    user.Name = Convert.ToString(Result["Name"]);
                    user.RoleName = Convert.ToString(Result["RoleName"]);
                }
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(secretKey);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Role, user.RoleName)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                loginResponseDTO.Token = tokenHandler.WriteToken(token);
                loginResponseDTO.User = user;

               


            }
            catch (Exception ex)
            {

                loginResponseDTO.Token = null;
                loginResponseDTO.User = null;

            }
            finally
            {
                // Result.Close();
                //Result.Dispose();
            }









            return loginResponseDTO;
        }
      
    }
}
