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
    public class ClientRepository : IClientRepository
    {
        public static IConfiguration AppSetting;
        public ClientRepository()
        {
            AppSetting = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
        }
        public async Task<ClientMasterResponseDTO> CreateClientAync(ClientMasterViewModelDTO clientMasterViewModelDTO)
        {      
            ClientMasterResponseDTO clientMasterResponseDTO = new ClientMasterResponseDTO();
            IDataParameter[] DParam = { };
            List<SqlParameter> lstParam = new List<SqlParameter>();
            DataAccessLayerBaseClass DataAccess = DataAccessLayerFactory.GetDataAccessLayer();
            /// lstParam.Add(new SqlParameter { ParameterName = "@Type", SqlDbType = SqlDbType.VarChar, Size = 50, Value = "" });
            lstParam.Add(new SqlParameter { ParameterName = "@ClientId", SqlDbType = SqlDbType.VarChar, Size = 50, Value = Convert.ToInt32(clientMasterViewModelDTO.ClientID == null ? 0 : clientMasterViewModelDTO.ClientID) });
            lstParam.Add(new SqlParameter { ParameterName = "@ClientName", SqlDbType = SqlDbType.VarChar, Size = 50, Value = clientMasterViewModelDTO.ClientName });
            lstParam.Add(new SqlParameter { ParameterName = "@ClientAddress", SqlDbType = SqlDbType.VarChar, Size = 500, Value = clientMasterViewModelDTO.ClientAddress });
            lstParam.Add(new SqlParameter { ParameterName = "@SPOCName", SqlDbType = SqlDbType.VarChar, Size = 500, Value = clientMasterViewModelDTO.SPOCName });
            lstParam.Add(new SqlParameter { ParameterName = "@SPOCPhone", SqlDbType = SqlDbType.VarChar, Size = 50, Value = clientMasterViewModelDTO.SPOCPhone });
            lstParam.Add(new SqlParameter { ParameterName = "@SPOCEmail", SqlDbType = SqlDbType.VarChar, Size = 500, Value = clientMasterViewModelDTO.SPOCEmail });
            lstParam.Add(new SqlParameter { ParameterName = "@CrBy", SqlDbType = SqlDbType.Int, Size = 500, Value = clientMasterViewModelDTO.Crby });

            lstParam.Add(new SqlParameter { ParameterName = "@ClientsPANCardNo", SqlDbType = SqlDbType.VarChar, Size = 500, Value = clientMasterViewModelDTO.PanCardNo == null ? "" : clientMasterViewModelDTO.PanCardNo });
            lstParam.Add(new SqlParameter { ParameterName = "@ClientsGSTNo", SqlDbType = SqlDbType.VarChar, Size = 500, Value = clientMasterViewModelDTO.GSTNo == null ? "" : clientMasterViewModelDTO.GSTNo });
            lstParam.Add(new SqlParameter { ParameterName = "@ClientsTANNo", SqlDbType = SqlDbType.VarChar, Size = 500, Value = clientMasterViewModelDTO.TanNo == null ? "" : clientMasterViewModelDTO.TanNo });
            lstParam.Add(new SqlParameter { ParameterName = "@ClientsTradeLicenseCENo", SqlDbType = SqlDbType.VarChar, Size = 500, Value = clientMasterViewModelDTO.TradeLicenseNo });
            lstParam.Add(new SqlParameter { ParameterName = "@TradeLicenseValidTill", SqlDbType = SqlDbType.Date, Size = 500, Value = clientMasterViewModelDTO.TradeLicenseValid });
            lstParam.Add(new SqlParameter { ParameterName = "@ClientsCIN", SqlDbType = SqlDbType.VarChar, Size = 500, Value = clientMasterViewModelDTO.Cin == null ? "" : clientMasterViewModelDTO.Cin });
            lstParam.Add(new SqlParameter { ParameterName = "@CompanyLogo", SqlDbType = SqlDbType.VarChar, Size = 500, Value = clientMasterViewModelDTO.CompanyLogo == null ? "" : clientMasterViewModelDTO.CompanyLogo });
            lstParam.Add(new SqlParameter { ParameterName = "@DateOfRegistration", SqlDbType = SqlDbType.Date, Size = 500, Value = clientMasterViewModelDTO.DateofRegistration });
            lstParam.Add(new SqlParameter { ParameterName = "@IsBlocked", SqlDbType = SqlDbType.Bit, Size = 500, Value = Convert.ToBoolean(clientMasterViewModelDTO.IsActive) });


            DParam = lstParam.ToArray();
            DataSet Result = DataAccess.ExecuteDataSet("AddEditClient", CommandType.StoredProcedure, DParam);
            


            try
            {

                ClientMasterResponseDTO.Status = Convert.ToInt32(Result.Tables[0].Rows[0]["Result"]);
                ClientMasterResponseDTO.Message = Convert.ToString(Result.Tables[0].Rows[0]["Msg"]);
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                ClientMasterResponseDTO.Status = 2;
                ClientMasterResponseDTO.Message = ex.Message;
            }
            finally
            {
                // Result.Close();
                //Result.Dispose();
            }
            return clientMasterResponseDTO;
        
        }

    }
}
