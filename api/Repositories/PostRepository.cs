using MongoDB.Driver;
using DncApiTest.Models;

namespace DncApiTest.Repositories
{
    public class PostRepository
    {
        private readonly IMongoCollection<Post> _posts;

        public PostRepository(IConfiguration configuration)
        {
            var mongoClient = new MongoClient(configuration.GetValue<string>("MongoDB:ConnectionString") ?? "mongodb://mongodb:27017");
            var database = mongoClient.GetDatabase(configuration.GetValue<string>("MongoDB:DatabaseName") ?? "blogdb");
            _posts = database.GetCollection<Post>("Posts");
        }

        public IEnumerable<Post> GetAll() => 
            _posts.Find(post => true).ToList();

        public Post? GetById(Guid id) => 
            _posts.Find(post => post.Id == id).FirstOrDefault();

        public Post Create(Post post)
        {
            post.Id = Guid.NewGuid();
            _posts.InsertOne(post);
            return post;
        }

        public Post? Update(Guid id, Post post)
        {
            post.Id = id; // Ensure the ID matches
            var result = _posts.ReplaceOne(p => p.Id == id, post);
            
            return result.ModifiedCount > 0 ? post : null;
        }

        public bool Delete(Guid id)
        {
            var result = _posts.DeleteOne(post => post.Id == id);
            return result.DeletedCount > 0;
        }
    }
} 