using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Learning_APP.Application.DTO
{
    public class UpdateClassGroupSubjectStudentActivityDto
    {
        public Guid ActivityId { get; set; }

        public Guid StudentId { get; set; }
        public string FileBase64 { get; set; }
        public string FileName { get; set; }
        public bool? IsProcessed { get; set; } = false;
    }
}
