using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPoint.Domain.Model
{
    public class Tag
    {
        public Guid TagId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public ICollection<TaskTag> TaskTags { get; set; }
    }
}
