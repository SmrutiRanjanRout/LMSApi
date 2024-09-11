using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model.Models.Dto
{
    public class ClientMasterViewModelDTO
    {

        public int? ClientID { get; set; }

        [Required(ErrorMessage = "Please provide Client Name")]
        public string ClientName { get; set; }
        [Required(ErrorMessage = "Please provide Client Address.")]
        public string ClientAddress { get; set; }
        [Required(ErrorMessage = "Please provide SPOC Name.")]
        public string SPOCName { get; set; }

        [Required(ErrorMessage = "Please provide SPOC Phone Number.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string SPOCPhone { get; set; }
        [Required(ErrorMessage = "Please provide SPOC Email Address.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        // [RegularExpression(@"^[A-Za-z0-9]+@([a-zA-Z]+\\.)+[a-zA-Z]{2,6}]&")]
        public string SPOCEmail { get; set; }


        public string PanCardNo { get; set; }
        public string GSTNo { get; set; }
        public string TanNo { get; set; }
        public string TradeLicenseNo { get; set; }
        public string TradeLicenseValid { get; set; }
        public string Cin { get; set; }
        public string DateofRegistration { get; set; }
        public bool IsActive { get; set; }

        public string CompanyLogo { get; set; }
        public int Crby { get; set; }
    }
}
