﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Learning_APP.Application.DTO
{
    public class updateNotificationDto
    {
        public Guid ActivityId { get; set; }

        public Guid ClassGroupSubjectStudentActivityId { get; set; }

        public Guid StudentId { get; set; }

        public string ClassGroupSubjectClassGroupSubjectId { get; set; }
        public bool? IsProcessed { get; set; } = false;
    }
}
