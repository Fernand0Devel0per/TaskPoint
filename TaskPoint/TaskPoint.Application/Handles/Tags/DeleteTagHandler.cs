using MediatR;
using TaskPoint.Application.Commands.Request.Tag;
using TaskPoint.Application.Commands.Response.Tag;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Tags;

public class DeleteTagHandler : IRequestHandler<DeleteTagCommand, DeleteTagResponse>
{
    private readonly ITagRepository<Tag> _repository;

    public DeleteTagHandler(ITagRepository<Tag> repository)
    {
        _repository = repository;
    }

    public async Task<DeleteTagResponse> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        var tag = await _repository.FindByIdAsync(request.TagId);
        if (tag is null)
        {
            return new DeleteTagResponse { Success = false, Message = "Tag not found." };
        }

        try
        {
            await _repository.DeleteAsync(tag);
            return new DeleteTagResponse { Success = true, Message = "Tag deleted successfully." };
        }
        catch (Exception ex)
        {
            return new DeleteTagResponse
            {
                Success = false,
                Message = "An internal error occurred while processing your request. Please contact support if the problem persists.",
                Errors = { ex.Message }
            };
        }
    }
}
