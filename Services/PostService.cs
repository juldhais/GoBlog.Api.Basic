using GoBlog.Api.Models;
using GoBlog.Api.Repositories;

namespace GoBlog.Api.Services;

public class PostService
{
    private readonly DataContext db;

    public PostService(DataContext db)
    {
        this.db = db;
    }

    public Post Get(int id)
    {
        return db.Post.Find(id);
    }

    public List<Post> GetList()
    {
        return db.Post.ToList();
    }

    public Post Create(Post post)
    {
        db.Post.Add(post);
        db.SaveChanges();
        return post;
    }

    public Post Update(Post post)
    {
        db.Post.Update(post);
        db.SaveChanges();
        return post;
    }

    public void Delete(int id)
    {
        var post = db.Post.Find(id);
        db.Post.Remove(post);
        db.SaveChanges();
    }
}
