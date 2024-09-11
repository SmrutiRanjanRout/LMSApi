using LMS.Business.Repository;
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
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _userRepo;
        protected APIResponse _response;
        public InvoiceController(IInvoiceRepository userRepo)
        {
            _userRepo = userRepo;
            _response = new();
        }
        [HttpGet]
        public string Get()
        {
            return "Jitesh";
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] InvoiceDetailsRequestDTO model)
        {
            var InvoiceModelResponseDTO = await _userRepo.CreateInvoiceAync(model);
            if (InvoiceModelResponseDTO.Status == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = InvoiceModelResponseDTO;
            return Ok(_response);

        }
    }
}

