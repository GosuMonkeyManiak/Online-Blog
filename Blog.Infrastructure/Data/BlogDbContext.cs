namespace Blog.Infrastructure.Data
{
    using Blog.Infrastructure.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class BlogDbContext : IdentityDbContext<User>
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Comment>()
                .HasOne(c => c.Article)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.ArticleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
                .HasOne(c => c.Author)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Article>()
                .HasOne(a => a.Author)
                .WithMany(a => a.Articles)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}