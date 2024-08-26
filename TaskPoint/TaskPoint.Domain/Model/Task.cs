using TaskPoint.Domain.Tools.Enums;
using TaskStatus = TaskPoint.Domain.Tools.Enums.TaskStatus;

namespace TaskPoint.Domain.Model
{
    public class Task
    {
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDated { get; set; }

        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<TaskTag> TaskTags { get; set; }
    }
}
