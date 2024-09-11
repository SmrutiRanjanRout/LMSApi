using LMS.Business.Repository.IRepostiory;
using LMS.Model.Models.Dto;
using LMS.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _userRepo;
        protected APIResponse _response;
        public CourseController(ICourseRepository userRepo)
        {
            _userRepo = userRepo;
            _response = new();
        }
        [HttpGet]
        public string Get()
        {
            return "Smruti";
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CourseModelDTO model)
        {
            var CourseModelResponseDTO = await _userRepo.CreateCourseAync(model);
            if (CourseModelResponseDTO.Status == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = CourseModelResponseDTO;
            return Ok(_response);
        }
    }
}
