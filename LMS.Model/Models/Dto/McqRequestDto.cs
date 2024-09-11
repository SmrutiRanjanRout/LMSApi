using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model.Models.Dto
{
    public class McqRequestDto
    {

        public int? Slno { get; set; }
        public int? TestId { get; set; }
        [Required]
        public string ClientID { get; set; }
        [Required]
        public int BatchID { get; set; }
        [Required]
        public string TestName { get; set; }
        [Required]
        public int NumberofAttemptAllowed { get; set; }
        [Required]
        public string ValidTill { get; set; }
        [Required]
        public string TestDescription { get; set; }
        [Required]
        public string TimeAllowed { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string ScoreTobemailed1 { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string ScoreTobemailed2 { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string ScoreTobemailed3 { get; set; }
        public int CreatedBy { get; set; }

    }
}
