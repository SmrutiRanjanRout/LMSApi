using LMS.Model.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Business.Repository.IRepostiory
{
    public interface IMenuRepository
    {
        Task<MenuModelResponseDTO> CreateMenuAync(MenuModelRequestDTO menuModelRequestDTO);

    }
}
