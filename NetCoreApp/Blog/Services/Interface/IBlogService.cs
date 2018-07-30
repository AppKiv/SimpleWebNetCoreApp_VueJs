using Blog.Model;
using Blog.Model.ViewModel;
using System.Threading.Tasks;

namespace Blog.Services.Interface
{
    public interface IBlogService
    {
        PageViewModel<PostPreviewModel> GetPostsByTag(string tags);
        PageViewModel<PostModel> GetPostsById(int id);
        PageViewModel<PostPreviewModel> GetPosts();
        PageViewModel<TagViewModel> GetTags();
        Task<PageViewModel<TagViewModel>> GetTagsAsyncPage();

    }
}
