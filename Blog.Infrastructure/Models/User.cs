namespace Blog.Infrastructure.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public User()
        {
            this.Articles = new HashSet<Article>();
            this.Comments = new HashSet<Comment>();
        }

        public ICollection<Article> Articles { get; init; }

        public ICollection<Comment> Comments { get; init; }
    }
}
