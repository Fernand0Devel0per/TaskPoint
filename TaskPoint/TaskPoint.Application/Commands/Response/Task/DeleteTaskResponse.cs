using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPoint.Application.Commands.Response.Task;
using TaskPoint.Domain.Model;

namespace TaskPoint.Application.Commands.Response.Task
{
    public record DeleteTaskResponse : BaseResponse
    {
        var task = await _repository.FindByIdAsync(request.TaskId);
        if (task is null)
        {
            return new DeleteTaskResponse { Success = false, Message = "Task not found." };
}

try
{
    await _repository.DeleteAsync(task);
    return new DeleteTaskResponse { Success = true, Message = "Task deleted successfully." };
}
catch (Exception ex)
{
    return new DeleteTaskResponse
    {
        Success = false,
        Message = "An internal error occurred while processing your request. Please contact support if the problem persists.",
        Errors = { ex.Message }
    };
}
    }
}
