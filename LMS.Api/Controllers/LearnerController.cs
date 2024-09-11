using LMS.Business.Repository.IRepostiory;
using LMS.Model.Models;
using LMS.Model.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearnerController : ControllerBase
    {
        private readonly ILearnerRepository _userRepo;
        protected APIResponse _response;
        public LearnerController(ILearnerRepository userRepo)
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
        public async Task<IActionResult> CreateLearner([FromBody] LearnerRequestDTO model)
        {
            var LearnerResponseDTO = await _userRepo.CreateLearnerAync(model);
            if (LearnerResponseDTO.Status == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = LearnerResponseDTO;
            return Ok(_response);

        }
    }
}
