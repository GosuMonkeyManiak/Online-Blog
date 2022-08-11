namespace Blog.Infrastructure.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Blog.Infrastructure.Common.DataConstraints;

    public class Comment
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.Now;
        }

        [Key]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; }

        [Required]
        [ForeignKey(nameof(Author))]
        public string AuthorId { get; init; }

        public User Author { get; init; }

        [Required]
        [ForeignKey(nameof(Article))]
        [MaxLength(IdMaxLength)]
        public string ArticleId { get; init; }

        public Article Article { get; init; }

        [Required]
        public string Content { get; init; }

        public DateTime CreatedOn { get; init; }

        public bool IsDeleted { get; init; }
    }
}
