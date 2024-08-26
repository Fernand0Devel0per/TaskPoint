using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPoint.Domain.Model
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Task Task { get; set; }
        public User User { get; set; }
    }
}
