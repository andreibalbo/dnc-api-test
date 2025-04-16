using DncApiTest.Models;

namespace DncApiTest.Repositories
{
    public class PostRepository
    {
        private readonly List<Post> _posts = new();
        private int _nextId = 1;

        public IEnumerable<Post> GetAll() => _posts;

        public Post? GetById(int id) => _posts.FirstOrDefault(p => p.Id == id);

        public Post Create(Post post)
        {
            post.Id = _nextId++;
            _posts.Add(post);
            return post;
        }

        public Post? Update(int id, Post post)
        {
            var existingPost = _posts.FirstOrDefault(p => p.Id == id);
            if (existingPost == null) return null;

            existingPost.Title = post.Title;
            existingPost.Content = post.Content;
            return existingPost;
        }

        public bool Delete(int id)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            if (post == null) return false;

            _posts.Remove(post);
            return true;
        }
    }
} 