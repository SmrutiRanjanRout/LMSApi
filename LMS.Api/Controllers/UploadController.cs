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
    public class UploadController : ControllerBase
    {
        private readonly IUploadRepository _userRepo;
        protected APIResponse _response;
        public UploadController(IUploadRepository userRepo)
        {
            _userRepo = userRepo;
            _response = new();
        }
        [HttpGet]
        public string Get()
        {
            return "Jitesh";
        }

      
    }
}

    
