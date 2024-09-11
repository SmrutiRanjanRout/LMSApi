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
    public class McqRepostiory : IMcqRepostiory
    {
        public static IConfiguration AppSetting;

        public McqRepostiory()
        {
            AppSetting = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
           
        }
        public async Task<McqResponceDTO> CreateMcqAync(McqRequestDto mcqRequestDto)
        {
            McqResponceDTO mcqResponceDTO = new McqResponceDTO();
            IDataParameter[] DParam = { };
            List<SqlParameter> lstParam = new List<SqlParameter>();
            DataAccessLayerBaseClass DataAccess = DataAccessLayerFactory.GetDataAccessLayer();
            /// lstParam.Add(new SqlParameter { ParameterName = "@Type", SqlDbType = SqlDbType.VarChar, Size = 50, Value = "" });
            lstParam.Add(new SqlParameter { ParameterName = "@TestId", SqlDbType = SqlDbType.Int, Size = 50, Value = 0 });
            lstParam.Add(new SqlParameter { ParameterName = "@ClientID", SqlDbType = SqlDbType.VarChar, Size = 500, Value = mcqRequestDto.ClientID });
            lstParam.Add(new SqlParameter { ParameterName = "@BatchID", SqlDbType = SqlDbType.Int, Size = 500, Value = mcqRequestDto.BatchID });
            lstParam.Add(new SqlParameter { ParameterName = "@TestName", SqlDbType = SqlDbType.VarChar, Size = 50, Value = mcqRequestDto.TestName });
            lstParam.Add(new SqlParameter { ParameterName = "@NumberofAttemptAllowed", SqlDbType = SqlDbType.Int, Size = 500, Value = mcqRequestDto.NumberofAttemptAllowed });
            lstParam.Add(new SqlParameter { ParameterName = "@TestDescription", SqlDbType = SqlDbType.VarChar, Size = 500, Value = mcqRequestDto.TestDescription });
            lstParam.Add(new SqlParameter { ParameterName = "@TimeAllowed", SqlDbType = SqlDbType.VarChar, Size = 500, Value = mcqRequestDto.ClientID });
            lstParam.Add(new SqlParameter { ParameterName = "@ValidTill", SqlDbType = SqlDbType.DateTime, Size = 500, Value = Convert.ToDateTime(mcqRequestDto.ValidTill) });
            lstParam.Add(new SqlParameter { ParameterName = "@ScoreTobemailed1", SqlDbType = SqlDbType.VarChar, Size = 500, Value = mcqRequestDto.ScoreTobemailed1 });
            lstParam.Add(new SqlParameter { ParameterName = "@ScoreTobemailed2", SqlDbType = SqlDbType.VarChar, Size = 500, Value = mcqRequestDto.ScoreTobemailed2 });
            lstParam.Add(new SqlParameter { ParameterName = "@ScoreTobemailed3", SqlDbType = SqlDbType.VarChar, Size = 500, Value = mcqRequestDto.ScoreTobemailed3 });
            lstParam.Add(new SqlParameter { ParameterName = "@CreatedBy", SqlDbType = SqlDbType.Int, Size = 500, Value = mcqRequestDto.CreatedBy });

            DParam = lstParam.ToArray();
            DataSet Result = DataAccess.ExecuteDataSet("AddEditTestConfiguration", CommandType.StoredProcedure, DParam);
           


            try
            {

                mcqResponceDTO.Status = Convert.ToInt32(Result.Tables[0].Rows[0]["Result"]);
                mcqResponceDTO.Message = Convert.ToString(Result.Tables[0].Rows[0]["Msg"]);


            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                mcqResponceDTO.Status = 2;
                mcqResponceDTO.Message = ex.Message;
              
            }
            finally
            {
                // Result.Close();
                //Result.Dispose();
            }
            return mcqResponceDTO;
        }
    }
}
