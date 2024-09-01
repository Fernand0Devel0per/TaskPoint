using MediatR;
using TaskPoint.Application.Commands.Request.Tag;
using TaskPoint.Application.Commands.Response.Tag;
using TaskPoint.Application.Mapping.Tags;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Tags;

public class UpdateTagHandler : IRequestHandler<UpdateTagCommand, UpdateTagResponse>
{
    private readonly ITagRepository<Tag> _repository;

    public UpdateTagHandler(ITagRepository<Tag> repository)
    {
        _repository = repository;
    }

    public async Task<UpdateTagResponse> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        var tag = await _repository.FindByIdAsync(request.TagId);
        if (tag is null)
        {
            return new UpdateTagResponse { Success = false, Message = "Tag not found." };
        }

        var existingTag = await _repository.FindByNameAsync(request.Name, request.Color);
        if (existingTag is not null && existingTag.TagId != request.TagId)
        {
            return new UpdateTagResponse { Success = false, Message = "A tag with this name and color already exists." };
        }

        try
        {
            request.UpdateEntity(tag);

            await _repository.UpdateAsync(tag);
            return new UpdateTagResponse { Success = true, Message = "Tag updated successfully." };
        }
        catch (Exception ex)
        {
            return new UpdateTagResponse
            {
                Success = false,
                Message = "An internal error occurred while processing your request. Please contact support if the problem persists.",
                Errors = { ex.Message }
            };
        }
    }
}
