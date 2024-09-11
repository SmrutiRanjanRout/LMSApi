using LMS.Business.Repository.IRepostiory;
using LMS.DataAccess;
using LMS.Model.Models.Dto;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Business.Repository
{
    public interface PurchaseOrderRepository
    {
        public class PurchaseOrderRepository : IPurchaseOrderRepository
        {
            public static IConfiguration AppSetting;

            public PurchaseOrderRepository()
            {
                AppSetting = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json")
                     .Build();

            }
            public async Task<PurchaseOrderResponseDTO> CreatePurchaseAync(PurchaseOrderRequestDTO purchaseOrderRequestDTO)
            {
                PurchaseOrderResponseDTO purchaseOrderResponseDTO = new PurchaseOrderResponseDTO();
                IDataParameter[] DParam = { };
                List<SqlParameter> lstParam = new List<SqlParameter>();
                DataAccessLayerBaseClass DataAccess = DataAccessLayerFactory.GetDataAccessLayer();
                /// lstParam.Add(new SqlParameter { ParameterName = "@Type", SqlDbType = SqlDbType.VarChar, Size = 50, Value = "" });
                lstParam.Add(new SqlParameter { ParameterName = "@ID", SqlDbType = SqlDbType.VarChar, Size = 50, Value = Convert.ToInt32(purchaseOrderRequestDTO.PoId == null ? 0 : purchaseOrderRequestDTO.PoId) });
                lstParam.Add(new SqlParameter { ParameterName = "@PoNo", SqlDbType = SqlDbType.VarChar, Size = 500, Value = Convert.ToString(purchaseOrderRequestDTO.PoNo) });
                lstParam.Add(new SqlParameter { ParameterName = "@PoDate", SqlDbType = SqlDbType.Date, Size = 500, Value = Convert.ToDateTime(purchaseOrderRequestDTO.PoDate) });
                lstParam.Add(new SqlParameter { ParameterName = "@VendorId", SqlDbType = SqlDbType.VarChar, Size = 500, Value = Convert.ToInt32(purchaseOrderRequestDTO.VendorId) });
                lstParam.Add(new SqlParameter { ParameterName = "@Description", SqlDbType = SqlDbType.VarChar, Size = 50, Value = Convert.ToString(purchaseOrderRequestDTO.Description) });
                lstParam.Add(new SqlParameter { ParameterName = "@TrainingDays", SqlDbType = SqlDbType.Int, Size = 500, Value = Convert.ToInt32(purchaseOrderRequestDTO.TrainingDays) });
                lstParam.Add(new SqlParameter { ParameterName = "@Amount", SqlDbType = SqlDbType.Decimal, Size = 500, Value = Convert.ToDecimal(purchaseOrderRequestDTO.Amount) });
                /// lstParam.Add(new SqlParameter { ParameterName = "@Type", SqlDbType = SqlDbType.VarChar, Size = 50, Value = "" });
                lstParam.Add(new SqlParameter { ParameterName = "@TotalAmount", SqlDbType = SqlDbType.Decimal, Size = 50, Value = Convert.ToDecimal(purchaseOrderRequestDTO.TotalAmount) });
                lstParam.Add(new SqlParameter { ParameterName = "@CreatedBy", SqlDbType = SqlDbType.Int, Size = 500, Value = purchaseOrderRequestDTO.CreatedBy });


                DParam = lstParam.ToArray();
                DataSet Result = DataAccess.ExecuteDataSet("AddEditTestConfiguration", CommandType.StoredProcedure, DParam);


                try
                {

                    purchaseOrderResponseDTO.Status = Convert.ToInt32(Result.Tables[0].Rows[0]["Result"]);
                    purchaseOrderResponseDTO.Message = Convert.ToString(Result.Tables[0].Rows[0]["Msg"]);



                }
                catch (Exception ex)
                {
                    //log.Error(ex.Message);
                    purchaseOrderResponseDTO.Status = 2;
                    purchaseOrderResponseDTO.Message = ex.Message;

                }
                finally
                {
                    // Result.Close();
                    //Result.Dispose();
                }
                return purchaseOrderResponseDTO;
            }
        }
    }
}
