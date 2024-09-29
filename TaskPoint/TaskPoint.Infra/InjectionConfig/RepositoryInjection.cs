using Microsoft.Extensions.DependencyInjection;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;
using TaskPoint.Persistence.Repository;
using Task = TaskPoint.Domain.Model.Task;

namespace TaskPoint.Infra.InjectionConfig
{
    public static class RepositoryInjection
    {
        public static void AddRepositoryInjections(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository<User>, UserRepository>();
            services.AddScoped<ITaskRepository<Task>, TaskRepository>();
            services.AddScoped<ITagRepository<Tag>, TagRepository>();
            services.AddScoped<ICommentRepository<Comment>, CommentRepository>();
            services.AddScoped<IProjectRepository<Project>, ProjectRepository>();
            services.AddScoped<ITaskTagRepository<TaskTag>, TaskTagRepository>();
        }
    }
}
