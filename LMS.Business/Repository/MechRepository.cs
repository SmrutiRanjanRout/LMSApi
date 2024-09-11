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
    public class MechRepository
    {
        public static IConfiguration AppSetting;

        public MechRepository()
        {
            AppSetting = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

        }
        public async Task<AssetResponseDTO> CreateMechanicalAync(AssetRequestDTO assetRequestDTO)
        {
            AssetResponseDTO assetResponseDTO = new AssetResponseDTO();
            IDataParameter[] DParam = { };
            List<SqlParameter> lstParam = new List<SqlParameter>();
            DataAccessLayerBaseClass DataAccess = DataAccessLayerFactory.GetDataAccessLayer();
            /// lstParam.Add(new SqlParameter { ParameterName = "@Type", SqlDbType = SqlDbType.VarChar, Size = 50, Value = "" });
            lstParam.Add(new SqlParameter { ParameterName = "@Mode", SqlDbType = SqlDbType.VarChar, Size = 50, Value = assetRequestDTO.Asset_Engr_Search });
            lstParam.Add(new SqlParameter { ParameterName = "@Text", SqlDbType = SqlDbType.VarChar, Size = 150, Value = assetRequestDTO.strName });
            lstParam.Add(new SqlParameter { ParameterName = "@Pename", SqlDbType = SqlDbType.VarChar, Size = 50, Value = assetRequestDTO.Pename });
            lstParam.Add(new SqlParameter { ParameterName = "@Penumber", SqlDbType = SqlDbType.VarChar, Size = 50, Value = assetRequestDTO.Penumber });
            DParam = lstParam.ToArray();
            IDataReader Result = DataAccess.ExecuteDataReader("Asset_Engr_Search", CommandType.StoredProcedure, DParam);
            AssetRequestDTO requestDTO=new AssetRequestDTO();
            try
            {
                while (Result.Read())
                {

                    requestDTO.Pename = Convert.ToString(Result["Pename"]);
                    requestDTO.Penumber = Convert.ToString(Result["PeNumber"]);
                }

            }

            
           
            catch (Exception ex)
            {
                AssetResponseDTO.Status = 2;
                AssetResponseDTO.Message = "Error";
            }
            finally
            {
                Result.Close();
                Result.Dispose();
            }
            return assetResponseDTO;
        }

    }
}
