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
using static LMS.Business.Repository.TestEntryRepository;

namespace LMS.Business.Repository
{
  
        public class TestEntryRepository : ITestEntryRepository
        {
            public static IConfiguration AppSetting;

            public TestEntryRepository()
            {
                AppSetting = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json")
                     .Build();

            }
            public async Task<TestEntryResponseDTO> CreateTestAync(TestEntryRequestDTO testEntryRequestDTO)
            {
                TestEntryResponseDTO testEntryResponseDTO = new TestEntryResponseDTO();
                IDataParameter[] DParam = { };
                List<SqlParameter> lstParam = new List<SqlParameter>();
                DataAccessLayerBaseClass DataAccess = DataAccessLayerFactory.GetDataAccessLayer();
                lstParam.Add(new SqlParameter { ParameterName = "@TestID", SqlDbType = SqlDbType.Int, Size = 50, Value = testEntryRequestDTO.TestID });
                lstParam.Add(new SqlParameter { ParameterName = "@QuestionNo", SqlDbType = SqlDbType.Int, Size = 50, Value = testEntryRequestDTO.QuestionNo });
                lstParam.Add(new SqlParameter { ParameterName = "@Question", SqlDbType = SqlDbType.VarChar, Size = 500, Value = testEntryRequestDTO.Question });
                lstParam.Add(new SqlParameter { ParameterName = "@Option1", SqlDbType = SqlDbType.VarChar, Size = 50, Value = testEntryRequestDTO.Option1 });
                lstParam.Add(new SqlParameter { ParameterName = "@Option2", SqlDbType = SqlDbType.VarChar, Size = 50, Value = testEntryRequestDTO.Option2 });
                lstParam.Add(new SqlParameter { ParameterName = "@Option3", SqlDbType = SqlDbType.VarChar, Size = 500, Value = testEntryRequestDTO.Option3 });
                lstParam.Add(new SqlParameter { ParameterName = "@Option4", SqlDbType = SqlDbType.VarChar, Size = 500, Value = testEntryRequestDTO.Option4 });
                lstParam.Add(new SqlParameter { ParameterName = "@RightAnswer", SqlDbType = SqlDbType.VarChar, Size = 500, Value = testEntryRequestDTO.RightAnswer });
                lstParam.Add(new SqlParameter { ParameterName = "@Marks", SqlDbType = SqlDbType.VarChar, Size = 500, Value = testEntryRequestDTO.Marks });
                lstParam.Add(new SqlParameter { ParameterName = "@Time", SqlDbType = SqlDbType.VarChar, Size = 500, Value = testEntryRequestDTO.Time });
                lstParam.Add(new SqlParameter { ParameterName = "@Active", SqlDbType = SqlDbType.Int, Size = 500, Value = Convert.ToInt32(testEntryRequestDTO.Active) });

                DParam = lstParam.ToArray();
                DataSet Result = DataAccess.ExecuteDataSet("AddEditMcqQuestion", CommandType.StoredProcedure, DParam);
                testEntryResponseDTO = new TestEntryResponseDTO();
                // List<DepartmentMaster> lstReportMaster = new List<DepartmentMaster>();


                try
                {

                    testEntryResponseDTO.Status = Convert.ToInt32(Result.Tables[0].Rows[0]["Result"]);
                    testEntryResponseDTO.Message = Convert.ToString(Result.Tables[0].Rows[0]["Msg"]);


                }
                catch (Exception ex)
                {
                    //log.Error(ex.Message);
                    testEntryResponseDTO.Status = 2;
                    testEntryResponseDTO.Message = ex.Message;
                }
                finally
                {
                    // Result.Close();
                    //Result.Dispose();
                }
                return testEntryResponseDTO;
            }
        }
    }

