using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model.Models.Dto
{
    public class LearnerRequestDTO
    {

        public int? LearnerID { get; set; }
        [Required]
        public int ClientID { get; set; }
        [Required]
        public int BatchID { get; set; }
        [Required]
        public string ? LearnerName { get; set; }
        [Required]
        public string ? LearnerAddress { get; set; }


        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string SPOCPhone { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        // [RegularExpression(@"^[A-Za-z0-9]+@([a-zA-Z]+\\.)+[a-zA-Z]{2,6}]&")]
        public string SPOCEmail { get; set; }

        public int Crby { get; set; }

        public string Color { get; set; }

        public string BatchName { get; set; }
    }
}
