using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Learning_App.Domain.Entities;

namespace Online_Learning_APP.Application.DTO
{
    public class GetClassGroupSubStudActivityDto
    {

        public Guid ActivityId { get; set; }

        public Guid StudentId { get; set; }
      //  public string ClassGroupSubjectClassGroupSubjectId { get; set; }
      
    }
}
