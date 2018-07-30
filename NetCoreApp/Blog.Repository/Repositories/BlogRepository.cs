using Blog.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Dapper;
using Blog.Model.ViewModel;
using Blog.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Repository
{
    public class BlogRepository : BaseRepository, IBlogRepository
    {

        public BlogRepository(ILogger<BaseRepository> logger, IOptions<Settings> config) : base(logger, config) { }

        public PageViewModel<PostModel> GetPostsById(int id)
        {
            var posts = WithConnectionSync(Connection => {
                return Connection.Query<PostModel>(@"select  p.post_id, p.header, p.preview, p.body, p.publish_date, p.tags from blog.post_get_by_id(@id) as p;", new { id });
            });

            var result = new PageViewModel<PostModel>(posts);
            result.TotalPages = result.Records.Count;
            return result;
        }

        public PageViewModel<PostPreviewModel> GetPosts()
        {
            var posts = WithConnectionSync(Connection => {
                return Connection.Query<PostPreviewModel>("select p.post_id, p.header, p.preview, p.body, p.publish_date from blog.post as p order by p.publish_date desc");
            });
            var result = new PageViewModel<PostPreviewModel>(posts);
            result.TotalPages = result.Records.Count;
            return result;
        }

        public PageViewModel<PostPreviewModel> GetPostsByTag(string tags)
        {
            var posts = WithConnectionSync( Connection => {
                return Connection.Query<PostPreviewModel>("select p.post_id, p.header, p.preview, p.publish_date from blog.post_get(@tags) as p", new {tags = tags });
            });
            var result = new PageViewModel<PostPreviewModel>(posts);
            result.TotalPages = result.Records.Count;
            return result;
        }

        public PageViewModel<TagViewModel> GetTags()
        {
            var tags = WithConnectionSync(Connection => {
                return Connection.Query<TagViewModel>("select tag, cnt from blog.tags_get();");
            });
            var result = new PageViewModel<TagViewModel>(tags);
            result.TotalPages = result.Records.Count;
            return result;
        }

        public async Task<IEnumerable<TagViewModel>> GetTagsAsync()
        {
            return  await WithConnectionAsync(async Connection =>
            {
                return await Connection.QueryAsync<TagViewModel>("select tag, cnt from blog.tags_get();");
            });
        }

        public async Task<PageViewModel<TagViewModel>> GetTagsAsyncPage()
        {
            return await WithConnectionAsync(async Connection =>
            {
                var tags = await Connection.QueryAsync<TagViewModel>("select tag, cnt from blog.tags_get();");
                var result = new PageViewModel<TagViewModel>(tags);
                result.TotalPages = result.Records.Count;
                return result;
            });
        }

    }
}
