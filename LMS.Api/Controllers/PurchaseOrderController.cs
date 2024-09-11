
using LMS.Business.Repository.IRepostiory;
using LMS.Model.Models;
using LMS.Model.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderRepository _userRepo;
        protected APIResponse _response;
        public PurchaseOrderController(IPurchaseOrderRepository userRepo)
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
        public async Task<IActionResult> CreatePurchase([FromBody] PurchaseOrderRequestDTO model)
        {
            var PurchaseOrderResponseDTO = await _userRepo.CreatePurchaseAync(model);
            if (PurchaseOrderResponseDTO.Status == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = PurchaseOrderResponseDTO;
            return Ok(_response);

        }
    }
}
