using LMS.Business.Repository.IRepostiory;
using LMS.DataAccess;
using LMS.Model.Models.Dto;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Business.Repository
{
    public class MenuRepository
    {
        public class MenuRepostiory : IMenuRepository
        {
            public static IConfiguration AppSetting;

            public MenuRepostiory()
            {
                AppSetting = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json")
                     .Build();

            }
            public async Task<MenuModelResponseDTO> CreateMenuAync(MenuModelRequestDTO menuModelRequestDto)
            {
                MenuModelResponseDTO menuModelResponseDTO = new MenuModelResponseDTO();               
                List<SqlParameter> lstParam = new List<SqlParameter>();
               
                lstParam.Add(new SqlParameter { ParameterName = "@pModuleId", SqlDbType = SqlDbType.Int, Size = 11, Value = menuModelRequestDto.ModuleId });
                lstParam.Add(new SqlParameter { ParameterName = "@pRoleID", SqlDbType = SqlDbType.Int, Size = 11, Value = menuModelRequestDto.RoleId });
                lstParam.Add(new SqlParameter { ParameterName = "@pPartyType", SqlDbType = SqlDbType.Int, Size = 11, Value = menuModelRequestDto.PartyType });
                IDataParameter[] DParam = { };
                DParam = lstParam.ToArray();
                DataAccessLayerBaseClass DataAccess = DataAccessLayerFactory.GetDataAccessLayer();
                IDataReader Result = DataAccess.ExecuteDataReader("GetMenuByRole", CommandType.StoredProcedure, DParam);
                List<MenuDTO> lstMenu = new List<MenuDTO>();
                MenuDTO ObjMenu = new MenuDTO();
                try
                {
                    int Status = 1;
                    while (Result.Read())
                    {
                        Status = 1;
                        ObjMenu = new MenuDTO();
                        ObjMenu.MenuId = Convert.ToInt32(Result["MenuId"]);
                        ObjMenu.MenuName = Convert.ToString(Result["MenuName"]);
                        ObjMenu.ActionUrl = Convert.ToString(Result["ActionUrl"] == null ? "" : Result["ActionUrl"]);
                        ObjMenu.ParentMenuId = Convert.ToInt32(Result["ParentMenuId"] == DBNull.Value ? 0 : Result["ParentMenuId"]);
                        lstMenu.Add(ObjMenu);
                    }

                    if (Status == 1)
                    {
                        menuModelResponseDTO.Status = 1;
                        menuModelResponseDTO.Message = "Success";
                    }
                    else
                    {
                        menuModelResponseDTO.Status = 0;
                        menuModelResponseDTO.Message = "Error";
                    }
                }
                catch (Exception ex)
                {
                    menuModelResponseDTO.Status = 0;
                    menuModelResponseDTO.Message = "Error";
                }
                finally
                {
                    Result.Close();
                    Result.Dispose();
                }
                return menuModelResponseDTO;
            }
        }
    }
}


