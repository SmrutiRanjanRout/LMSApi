
using LMS.Business.Repository;
using LMS.Business.Repository.IRepostiory;
using LMS.DataAccess;
using LMS.Model.Models.Dto;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace LMS.Business.Repository
{
    public class CourseRepository : ICourseRepository
    {
        public static IConfiguration AppSetting;
        public CourseRepository()
        {
            AppSetting = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
        }
        public async Task<CourseModelResponseDTO> CreateCourseAync(CourseModelDTO courseModelDTO)
        {
            CourseModelResponseDTO courseModelResponseDTO = new CourseModelResponseDTO();
            IDataParameter[] DParam = { };
            List<SqlParameter> lstParam = new List<SqlParameter>();
            DataAccessLayerBaseClass DataAccess = DataAccessLayerFactory.GetDataAccessLayer();
            /// lstParam.Add(new SqlParameter { ParameterName = "@Type", SqlDbType = SqlDbType.VarChar, Size = 50, Value = "" });
            lstParam.Add(new SqlParameter { ParameterName = "@CourseId", SqlDbType = SqlDbType.VarChar, Size = 50, Value = Convert.ToInt32(courseModelDTO.CourseId == null ? 0 : courseModelDTO.CourseId) });
            lstParam.Add(new SqlParameter { ParameterName = "@CourseTitle", SqlDbType = SqlDbType.VarChar, Size = 50, Value = courseModelDTO.CourseTitle });
            lstParam.Add(new SqlParameter { ParameterName = "@IsGeneric", SqlDbType = SqlDbType.VarChar, Size = 50, Value = courseModelDTO.IsGeneric });
            lstParam.Add(new SqlParameter { ParameterName = "@SpecificForClient", SqlDbType = SqlDbType.VarChar, Size = 50, Value = courseModelDTO.SpecificForClient });
            lstParam.Add(new SqlParameter { ParameterName = "@IsTechnical", SqlDbType = SqlDbType.VarChar, Size = 50, Value = courseModelDTO.IsTechnical });
            lstParam.Add(new SqlParameter { ParameterName = "@OnlyForIT", SqlDbType = SqlDbType.VarChar, Size = 50, Value = courseModelDTO.OnlyForIT });
            lstParam.Add(new SqlParameter { ParameterName = "@OnlyForNonIT", SqlDbType = SqlDbType.VarChar, Size = 50, Value = courseModelDTO.OnlyForNonIT });
            lstParam.Add(new SqlParameter { ParameterName = "@Keywords", SqlDbType = SqlDbType.VarChar, Size = 50, Value = courseModelDTO.Keywords });
            lstParam.Add(new SqlParameter { ParameterName = "@Duration", SqlDbType = SqlDbType.VarChar, Size = 50, Value = courseModelDTO.Duration });
            lstParam.Add(new SqlParameter { ParameterName = "@ClientID", SqlDbType = SqlDbType.VarChar, Size = 50, Value = Convert.ToInt32(courseModelDTO.ClientID == null ? 0 : courseModelDTO.ClientID) });
            lstParam.Add(new SqlParameter { ParameterName = "@ClientName", SqlDbType = SqlDbType.VarChar, Size = 50, Value = courseModelDTO.ClientName });
            lstParam.Add(new SqlParameter { ParameterName = "@CourseSummary", SqlDbType = SqlDbType.VarChar, Size = 50, Value = courseModelDTO.CourseSummary });
            lstParam.Add(new SqlParameter { ParameterName = "@CourseObjective", SqlDbType = SqlDbType.VarChar, Size = 50, Value = courseModelDTO.CourseObjective });
            lstParam.Add(new SqlParameter { ParameterName = "@CourseCurriculumFilePath", SqlDbType = SqlDbType.VarChar, Size = 50, Value = courseModelDTO.CourseCurriculumFilePath });
            lstParam.Add(new SqlParameter { ParameterName = "@WhatYouWillLearn", SqlDbType = SqlDbType.VarChar, Size = 50, Value = courseModelDTO.WhatYouWillLearn });
            lstParam.Add(new SqlParameter { ParameterName = "@CourseDetails", SqlDbType = SqlDbType.VarChar, Size = 50, Value = courseModelDTO.CourseDetails });
            lstParam.Add(new SqlParameter { ParameterName = "@CreatedBy", SqlDbType = SqlDbType.VarChar, Size = 50, Value = courseModelDTO.CreatedBy });

            DParam = lstParam.ToArray();
            DataSet Result = DataAccess.ExecuteDataSet("AddEditTestConfiguration", CommandType.StoredProcedure, DParam);



            try
            {

                CourseModelResponseDTO.Status = Convert.ToInt32(Result.Tables[0].Rows[0]["Result"]);
                CourseModelResponseDTO.Message = Convert.ToString(Result.Tables[0].Rows[0]["Msg"]);


            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                CourseModelResponseDTO.Status = 2;
                CourseModelResponseDTO.Message = ex.Message;

            }
            finally
            {
                // Result.Close();
                //Result.Dispose();
            }
            return courseModelResponseDTO;


        }
    }
}