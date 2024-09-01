using MediatR;
using TaskPoint.Application.Commands.Request.Tag;
using TaskPoint.Application.Commands.Response.Tag;
using TaskPoint.Application.Mapping.Tags;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Tags;

public class CreateTagHandler : IRequestHandler<CreateTagCommand, CreateTagResponse>
{
    private readonly ITagRepository<Tag> _repository;

    public CreateTagHandler(ITagRepository<Tag> repository)
    {
        _repository = repository;
    }

    public async Task<CreateTagResponse> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        
        var existingTag = await _repository.FindByNameAsync(request.Name);
        if (existingTag is not null)
        {
            return new CreateTagResponse { Success = false, Message = "A tag with this name already exists ." };
        }

        try
        {
            var tag = request.ToEntity(); 
            await _repository.AddAsync(tag);
            return new CreateTagResponse { Success = true, TagId = tag.TagId, Message = "Tag created successfully." };
        }
        catch (Exception ex)
        {
            return new CreateTagResponse
            {
                Success = false,
                Message = "An internal error occurred while processing your request. Please contact support if the problem persists.",
                Errors = { ex.Message }
            };
        }
    }
}
