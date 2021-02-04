using API.Models.Culture.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces.Culture.Posts
{
    public interface IPostRepository
    {

        public IEnumerable<Post> GetPosts();
        public Task<Post> GetPostById(Guid id);
        public Task<Post> AddPost(Post evento);
        public Task<Post> EditPost(Post evento);
        public Task<bool> DeletePost(Guid id);

    }
}
