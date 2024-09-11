using LMS.Business.Repository.IRepostiory;
using LMS.Model.Models;
using LMS.Model.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _userRepo;
        protected APIResponse _response;
        public ClientController(IClientRepository userRepo)
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
        public async Task<IActionResult> CreateClient([FromBody] ClientMasterViewModelDTO model)
        {
            var ClientMasterResponseDTO = await _userRepo.CreateClientAync(model);
            if (ClientMasterResponseDTO.Status == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = ClientMasterResponseDTO;
            return Ok(_response);

        }
    }
}
