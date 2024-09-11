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
    public class InvoiceRepository : IInvoiceRepository
    {
            public static IConfiguration AppSetting;

            public InvoiceRepository()
            {
                AppSetting = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json")
                     .Build();

            }
            public async Task<InvoiceDetailsResponseDTO> CreateInvoiceAync(InvoiceDetailsRequestDTO invoiceDetailsRequestDTO)
            {
                InvoiceDetailsResponseDTO invoiceDetailsResponseDTO = new InvoiceDetailsResponseDTO();
                IDataParameter[] DParam = { };
                List<SqlParameter> lstParam = new List<SqlParameter>();
                DataAccessLayerBaseClass DataAccess = DataAccessLayerFactory.GetDataAccessLayer();
                //lstParam.Add(new SqlParameter { ParameterName = "@ID", SqlDbType = SqlDbType.Int, Size = 50, Value = Id });

                DParam = lstParam.ToArray();
            IDataReader Result = DataAccess.ExecuteDataReader("GetPurchaseOrderByInvoice", CommandType.StoredProcedure);
            List<PurchaseOrderRequestDTO> lstPurchaseOrderModel = new List<PurchaseOrderRequestDTO>();
            int Status = 0;

            try
            {

                while (Result.Read())
                {
                    Status = 1;
                    lstPurchaseOrderModel.Add(new PurchaseOrderRequestDTO
                    {
                        PoId = Convert.ToInt32(Result["ID"]),
                        PoNo = Convert.ToString(Result["PoNo"])


                    });
                }

                if (Status == 1)
                {
                    invoiceDetailsResponseDTO.Status = 1;
                    invoiceDetailsResponseDTO.Message = "Success";

                }
                else
                {
                    invoiceDetailsResponseDTO.Status = 2;
                    invoiceDetailsResponseDTO.Message = "Error";
                }
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                invoiceDetailsResponseDTO.Status = 2;
                invoiceDetailsResponseDTO.Message = "Error";
            }
            finally
            {
                Result.Close();
                Result.Dispose();
            }
            return invoiceDetailsResponseDTO;
        }
    }
}
