﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VivesBlog.Model
{
    public class Person
    {
        public Person()
        {
            Articles = new List<Article>();
        }
        public int Id { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        public IList<Article> Articles { get; set; }
    }
}
