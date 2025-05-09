﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Learning_App.Domain.Entities
{
   public class ClassGroupSubjectStudentActivity
    {
        [Key]
        public Guid ClassGroupSubjectStudentActivityId { get; set; }


        [ForeignKey("ClassGroupSubject")]
        public Guid ClassGroupSubjectId { get; set; }
        public virtual ClassGroupSubject ClassGroupSubject { get; set; }


        [ForeignKey("Activity")]
        public Guid ActivityId { get; set; }
        public virtual Activity Activity { get; set; }

        [ForeignKey("Student")]
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }

        public string? Feedback { get; set; }
        public string? pdfUrl { get; set; }
        [ForeignKey("Submission")]
        public Guid? SubmissionId { get; set; }
        public virtual Submission Submission { get; set; }
        public bool IsProcessed { get; set; }
    }
}
