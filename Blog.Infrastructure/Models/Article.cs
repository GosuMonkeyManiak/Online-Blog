namespace Blog.Infrastructure.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    using static Blog.Infrastructure.Common.DataConstraints.Article;
    using static Blog.Infrastructure.Common.DataConstraints;

    public class Article
    {
        public Article()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.Now;
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; init; }

        [Required]
        public string Content { get; init; }

        public DateTime CreatedOn { get; init; } 

        [Required]
        [ForeignKey(nameof(Author))]
        public string AuthorId { get; init; }

        public User Author { get; init; }

        public bool IsDeleted { get; init; }

        public ICollection<Comment> Comments { get; init; }
    }
}
