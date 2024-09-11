using LMS.Business.Repository.IRepostiory;
using LMS.Model.Models;
using LMS.Model.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _userRepo;
        protected APIResponse _response;
        public MenuController(IMenuRepository userRepo)
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
        public async Task<IActionResult> CreateMenu([FromBody] MenuModelRequestDTO model)
        {
            var MenuModelResponseDTO = await _userRepo.CreateMenuAync(model);
            if (MenuModelResponseDTO.Status == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = MenuModelResponseDTO;
            return Ok(_response);

        }
    }
}
