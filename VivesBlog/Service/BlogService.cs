using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VivesBlog.Model;
using VivesBlog.Core;
using System;

namespace VivesBlog.Service
{
    public class BlogService
    {
        private readonly DB _context;
        private DbSet<Article> _articles;
        private PeopleService _peopleService;
        public BlogService()
        {
            var dbContext = new DBContext();
            _context = dbContext.GetDatabase;
            _articles = _context.Articles;
            _peopleService = new PeopleService();
        }

        public List<Article> GetArticles()
        {
            var articles = _articles
                .Include(a => a.Author)
                .ToList();
            return articles;
        }

        public Article GetArticle(int id)
        {
            var article = _articles
                .Include(a => a.Author)
                .FirstOrDefault(a => a.Id == id);
            return article;
        }

        public void AddArticle(Article article)
        {
            article.CreatedDate = DateTime.Now;
            _articles.Add(article);
            _context.SaveChanges();
        }

        public void DeleteArticle(int id)
        {
            var article = _articles.FirstOrDefault(p=> p.Id == id);
            _articles.Remove(article);
            _context.SaveChanges();
        }

        public void UpdateArticle(Article article)
        {
            var dbArticle = GetArticle(article.Id);

            dbArticle.Title = article.Title;
            dbArticle.Description = article.Description;
            dbArticle.Content = article.Content;
            dbArticle.AuthorId = article.AuthorId;

            _articles.Update(dbArticle);
            _context.SaveChanges();
        }

        public ArticleModel CreateArticleModel(Article article = null)
        {
            article ??= new Article(){Title = "",Description = "",Content = "",AuthorId = 0};
            var authors = _peopleService.GetOrderedPeople();

            var articleModel = new ArticleModel
            {
                Article = article,
                Authors = authors
            };

            return articleModel;
        }
    }
}
