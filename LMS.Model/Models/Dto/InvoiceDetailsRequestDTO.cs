using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model.Models.Dto
{
    
        public class InvoiceDetailsRequestDTO
    {

            public int ClientID { get; set; }

            public int InvoiceId { get; set; }

            public string InvoiceNo { get; set; }
           
            public string InvoiceDate { get; set; }
            public int PoId { get; set; }
            public string PONumber { get; set; }

            public int BatchId { get; set; }
            public decimal Qty { get; set; }
            public decimal UnitCharge { get; set; }

            public decimal TotalAmount { get; set; }
            public string SACCode { get; set; }
            public string SACDescription { get; set; }
            public string DiscountPercentageIfAny { get; set; }
            public string DiscountAmount { get; set; }

            public string Notes { get; set; }

            public int CreatedBy { get; set; }
        }
    
}
