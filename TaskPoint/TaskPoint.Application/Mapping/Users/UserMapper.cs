using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPoint.Application.Commands.Request.User;
using TaskPoint.Application.Commands.Response.User;
using TaskPoint.Application.Tools;
using TaskPoint.Domain.Model;
using TaskPoint.Domain.Tools.Enums;

namespace TaskPoint.Application.Mapping.Users
{
    public static class UserMapper
    {
        public static User ToEntity(this CreateUserCommand command)
        {
            return new User
            {
                UserId = Guid.NewGuid(),
                Username = command.Username,
                Email = command.Email,
                PasswordHash = PasswordHelper.CreateHashPassword(command.Password),
                Role = command.Role.ToEnum<UserRole>(),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };
        }

        public static CreateUserResponse ToResponse(this User entity)
        {
            return new CreateUserResponse(entity.UserId);
        }

        public static void UpdateEntity(this UpdateUserCommand command, User entity)
        {
            entity.Username = string.IsNullOrWhiteSpace(command.Username) ? entity.Username : command.Username;
            entity.Email = string.IsNullOrWhiteSpace(command.Email) ? entity.Email : command.Email;

            if (!string.IsNullOrEmpty(command.Password))
            {
                entity.PasswordHash = PasswordHelper.CreateHashPassword(command.Password);
            }

            entity.Role = string.IsNullOrWhiteSpace(command.Role) ? entity.Role : command.Role.ToEnum<UserRole>();
            entity.UpdatedDate = DateTime.Now;
        }

        public static GetUserResponse ToGetUserResponse(this User entity)
        {
            return new GetUserResponse
            {
                UserId = entity.UserId,
                Username = entity.Username,
                Email = entity.Email,
            };
        }

    }
}
