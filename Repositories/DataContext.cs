using GoBlog.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GoBlog.Api.Repositories;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }
    public DbSet<Post> Post { get; set; }
}
