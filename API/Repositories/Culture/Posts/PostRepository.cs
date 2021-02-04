using API.DataAccess;
using API.Interfaces.Culture.Posts;
using API.Models.Culture.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Culture.Posts
{
    public class PostRepository : IPostRepository
    {

        private readonly ToDentroContext _context;

        public PostRepository(ToDentroContext context)
        {
            _context = context;
        }

        public async Task<Post> AddPost(Post post)
        {
            if (post == null) return null;
            else
            {
                await _context.Posts.AddAsync(post);
                await _context.SaveChangesAsync();
                return post;
            }
        }

        public async Task<bool> DeletePost(Guid id)
        {
            if (id == null) return false;
            else
            {
                var post = await _context.Posts.FindAsync(id);
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Post> EditPost(Post post)
        {
            if (post == null) return null;
            else
            {
                var _post = await _context.Posts.FindAsync(post.Id);
                _post = post;
                
                _context.Entry(_post).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return post;
            }
        }

        public async Task<Post> GetPostById(Guid id)
        {
            if (id == null) return null;
            else
            {
                var post = await _context.Posts.FindAsync(id);
                return post;
            }
        }

        public IEnumerable<Post> GetPosts()
        {
            var postsList = _context.Posts.ToList();                        
            return postsList;
        }
    }
}
