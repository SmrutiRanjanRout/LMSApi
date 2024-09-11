using LMS.Business.Repository.IRepostiory;
using LMS.Model.Models;
using LMS.Model.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestEntryController : ControllerBase
    {
        private readonly ITestEntryRepository _userRepo;
        protected APIResponse _response;
        public TestEntryController(ITestEntryRepository userRepo)
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
        public async Task<IActionResult> CreateMCQ([FromBody] TestEntryRequestDTO model)
        {
            var testEntryResponse = await _userRepo.CreateTestAync(model);
            if (testEntryResponse.Status == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = testEntryResponse;
            return Ok(_response);

        }
    }
}
