using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace VivesBlog.Model
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Title { get; set; }
        [Required]
        public required string Description { get; set; }
        [Required]
        public required string Content { get; set; }
        [Required]
        public required int AuthorId { get; set; }
        public Person Author { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class ArticleModel
    {
        public Article Article { get; set; }
        public IList<Person> Authors { get; set; }
    }
}
