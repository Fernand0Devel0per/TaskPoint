using TaskPoint.Api.Endpoints.Comment;
using TaskPoint.Api.Endpoints.Project;
using TaskPoint.Api.Endpoints.Tag;
using TaskPoint.Api.Endpoints.Task;
using TaskPoint.Api.Endpoints.User;

namespace TaskPoint.Api.Endpoints
{
    public static class EndPointConfig
    {
        public static void ConfigureEndpoints(this WebApplication app)
        {
            CommentEndpoints.ConfigureCommentEndpoints(app);
            ProjectEndpoints.ConfigureProjectEndpoints(app);
            TagEndpoints.ConfigureTagEndpoints(app);
            UserEndpoints.ConfigureUserEndpoints(app);
            TaskEndpoints.ConfigureTaskEndpoints(app);
        }
    }
}
