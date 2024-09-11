using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model.Models.Dto
{
    public class CourseModelDTO
    {
        public int CourseId { get; set; }
        [Required]
        public string CourseTitle { get; set; }

        public bool IsGeneric { get; set; }
        public bool SpecificForClient { get; set; }
        public bool IsTechnical { get; set; }
        public bool OnlyForIT { get; set; }
        public bool OnlyForNonIT { get; set; }
        [Required]
        public string Keywords { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public int ClientID { get; set; }

        public string ClientName { get; set; }
        [Required]
        public string CourseSummary { get; set; }
        [Required]
        public string CourseObjective { get; set; }
        //  [Required]
        public string CourseCurriculumFilePath { get; set; }

        public string WhatYouWillLearn { get; set; }
        [Required]
        public string CourseDetails { get; set; }
        public int CreatedBy { get; set; }
    }
}
