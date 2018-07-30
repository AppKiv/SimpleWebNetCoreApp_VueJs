using Blog.Model;
using Blog.Model.ViewModel;
using Blog.Repository;
using Blog.Repository.Interfaces;
using Blog.Services.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services.Impelementation
{
    public class BlogService : IBlogService
    {
        IBlogRepository _repository;
        private readonly Settings _config;
        private readonly ILogger<BaseRepository> _logger;

        public BlogService(IBlogRepository repository, ILogger<BaseRepository> logger, IOptions<Settings> config)
        {
            _repository = repository;
            _config = config.Value;
            _logger = logger;
        }

        public PageViewModel<PostPreviewModel> GetPostsByTag(string tags)
        {
            return _repository.GetPostsByTag(tags);
        }

        public PageViewModel<PostPreviewModel> GetPosts()
        {
            return _repository.GetPosts();
        }

        public PageViewModel<PostModel> GetPostsById(int id)
        {
            return _repository.GetPostsById(id);
        }

        public PageViewModel<TagViewModel> GetTags()
        {
            return _repository.GetTags();
        }

        public Task<PageViewModel<TagViewModel>> GetTagsAsyncPage()
        {
            return _repository.GetTagsAsyncPage();
        }

    }
}
