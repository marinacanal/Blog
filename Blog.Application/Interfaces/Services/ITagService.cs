using Blog.Application.DTOs.Tag;

namespace Blog.Application.Interfaces.Services;

public interface ITagService
{
    public Task<TagResponseDto> CreateTagAsync(CreateTagRequestDto request);
    public Task<bool> DeleteTagAsync(Guid id);
    public Task<IEnumerable<TagResponseDto>> GetTagsAsync(GetTagsFilterDto filter);
}
