using LMS.Model.Models;
using LMS.Model.Models.Dto;


namespace LMS.Business.Repository.IRepostiory
{
    public interface IUserRepository
    {
     
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
      
    }
}
