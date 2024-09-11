using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model.Models.Dto
{
    public class PurchaseOrderRequestDTO
    {
        public int? PoId { get; set; }


        public string PoNo { get; set; }
        [Required]
        public string PoDate { get; set; }
        [Required]
        public string VendorId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string TrainingDays { get; set; }
        [Required]
        public string Amount { get; set; }
        [Required]
        public string TotalAmount { get; set; }

        public int CreatedBy { get; set; }

        public string VendorName { get; set; }
    }
}
