using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPoint.Domain.Model
{
    public class TaskTag
    {
        public Guid TaskId { get; set; }
        public Guid TagId { get; set; }
        public Task Task { get; set; }
        public Tag Tag { get; set; }
    }
}
