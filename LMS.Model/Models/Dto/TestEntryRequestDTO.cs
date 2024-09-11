using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model.Models.Dto
{
    public class TestEntryRequestDTO
    {
        public int? Id { get; set; }
        public int? TestID { get; set; }
        [Required]

        public int? QuestionNo { get; set; }
        [Required]

        public string Question { get; set; }
        [Required]

        public string Option1 { get; set; }
        [Required]

        public string Option2 { get; set; }
        [Required]

        public string Option3 { get; set; }
        [Required]

        public string Option4 { get; set; }
        [Required]

        public string RightAnswer { get; set; }
        [Required]

        public string Marks { get; set; }
        [Required]

        public string Time { get; set; }
        [Required]

        public bool Active { get; set; }
        public string flag { get; set; }

        public string IiId { get; set; }


    }
}
