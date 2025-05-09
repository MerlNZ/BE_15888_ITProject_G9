using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Learning_APP.Application.DTO
{
    public class CreateClassGroupSubjectDto
    {
       // public Guid? ClassGroupSubjectId { get; set; }
        public Guid ClassGroupId { get; set; }


        public Guid SubjectId { get; set; }
    }
}
