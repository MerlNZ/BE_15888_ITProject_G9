using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Learning_APP.Application.DTO
{
    public class SubmissionReviewDto
    {
        //public Guid SubmissionId { get; set; }
        //public string ActivityName { get; set; }
        //public string StudentName { get; set; }
        //public string Feedback { get; set; }
        //public int? Grade { get; set; }
        //public bool IsReviewed { get; set; }

        public Guid SubmissionId { get; set; }

        // These are for linking/navigation
        public Guid ActivityId { get; set; }
        public Guid StudentId { get; set; }

        public string ActivityName { get; set; }
        public string StudentName { get; set; }

        public string Feedback { get; set; }
        public int? Grade { get; set; }
        public bool IsReviewed { get; set; }
    }

}