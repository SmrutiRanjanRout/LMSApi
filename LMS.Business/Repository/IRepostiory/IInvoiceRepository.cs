using LMS.Model.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Business.Repository.IRepostiory
{
    public interface IInvoiceRepository
    {
        Task<InvoiceDetailsResponseDTO> CreateInvoiceAync(InvoiceDetailsRequestDTO invoiceDetailsRequestDTO);
       
    }
}
