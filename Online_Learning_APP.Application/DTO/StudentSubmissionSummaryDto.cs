using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Learning_APP.Application.DTO
{
    public class StudentSubmissionSummaryDto
    {
        public int TotalSubmissions { get; set; }
        public int UngradedSubmissions { get; set; }
        public int GradedSubmissions { get; set; }
        public int TotalActivities { get; set; }
    }
}
