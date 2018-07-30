using Blog.Model;
using Blog.Model.ViewModel;
using System.Threading.Tasks;

namespace Blog.Repository.Interfaces
{
    public interface IBlogRepository
    {
        PageViewModel<PostPreviewModel> GetPostsByTag(string tags);
        PageViewModel<PostPreviewModel> GetPosts();
        PageViewModel<PostModel> GetPostsById(int id);
        PageViewModel<TagViewModel> GetTags();
        Task<PageViewModel<TagViewModel>> GetTagsAsyncPage();

//        Task<IEnumerable<ConversationLessonQuestionLangView>> GetLessonQuestion(int lessonId, int langId, int translateLangId);
//        Task<IEnumerable<ConversationLessonAnswerLangView>> GetLessonAnswer(int lessonId, int langId, int translateLangId);
    }
}
