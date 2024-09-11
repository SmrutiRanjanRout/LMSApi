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
    public class LearnerRepository : ILearnerRepository
    {
        public static IConfiguration? AppSetting;
        public LearnerRepository()
        {
            AppSetting = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
        }
        public async Task<LearnerResponseDTO> CreateLearnerAync(LearnerRequestDTO learnerRequestDTO)
        {
            LearnerResponseDTO learnerResponseDTO = new LearnerResponseDTO();
            IDataParameter[] DParam = { };
            List<SqlParameter> lstParam = new List<SqlParameter>();
            DataAccessLayerBaseClass DataAccess = DataAccessLayerFactory.GetDataAccessLayer();
            /// lstParam.Add(new SqlParameter { ParameterName = "@Type", SqlDbType = SqlDbType.VarChar, Size = 50, Value = "" });
            lstParam.Add(new SqlParameter { ParameterName = "@LearnerId", SqlDbType = SqlDbType.VarChar, Size = 50, Value = Convert.ToInt32(learnerRequestDTO.LearnerID == null ? 0 : learnerRequestDTO.LearnerID) });
            lstParam.Add(new SqlParameter { ParameterName = "@ClientID", SqlDbType = SqlDbType.Int, Size = 500, Value = Convert.ToInt32(learnerRequestDTO.ClientID) });
            lstParam.Add(new SqlParameter { ParameterName = "@BatchID", SqlDbType = SqlDbType.Int, Size = 500, Value = learnerRequestDTO.BatchID });
            lstParam.Add(new SqlParameter { ParameterName = "@LearnerName", SqlDbType = SqlDbType.VarChar, Size = 50, Value = learnerRequestDTO.LearnerName });
            lstParam.Add(new SqlParameter { ParameterName = "@LearnerAddress", SqlDbType = SqlDbType.VarChar, Size = 500, Value = learnerRequestDTO.LearnerAddress });
            lstParam.Add(new SqlParameter { ParameterName = "@SPOCName", SqlDbType = SqlDbType.VarChar, Size = 500, Value = "" });
            lstParam.Add(new SqlParameter { ParameterName = "@SPOCPhone", SqlDbType = SqlDbType.VarChar, Size = 50, Value = learnerRequestDTO.SPOCPhone });
            lstParam.Add(new SqlParameter { ParameterName = "@SPOCEmail", SqlDbType = SqlDbType.VarChar, Size = 500, Value = learnerRequestDTO.SPOCEmail });
            lstParam.Add(new SqlParameter { ParameterName = "@CrBy", SqlDbType = SqlDbType.Int, Size = 500, Value = learnerRequestDTO.Crby });

            DParam = lstParam.ToArray();
            DataSet Result = DataAccess.ExecuteDataSet("AddEditLearner", CommandType.StoredProcedure, DParam);

            try
            {

                LearnerResponseDTO.Status = Convert.ToInt32(Result.Tables[0].Rows[0]["Result"]);
                LearnerResponseDTO.Message = Convert.ToString(Result.Tables[0].Rows[0]["Msg"]);


            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                LearnerResponseDTO.Status = 2;
                LearnerResponseDTO.Message = ex.Message;
            }
            finally
            {
                // Result.Close();
                //Result.Dispose();
            }
            return learnerResponseDTO;
        }
    }
}
