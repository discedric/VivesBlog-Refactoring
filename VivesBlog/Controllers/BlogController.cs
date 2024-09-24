using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VivesBlog.Core;
using VivesBlog.Model;
using VivesBlog.Service;

namespace VivesBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogService _blogService;

        public BlogController()
        {
            _blogService = new BlogService();
        }

        [HttpGet("Blog/Index")]
        public IActionResult Index()
        {
            var articles = _blogService.GetArticles();
            return View(articles);
        }

        [HttpGet("Blog/Create")]
        public IActionResult Create()
        {
            var articleModel = _blogService.CreateArticleModel();

            return View(articleModel);
        }

        [HttpPost("Blog/Create")]
        public IActionResult Create(Article article)
        {
            if (!ModelState.IsValid)
            {
                var articleModel = _blogService.CreateArticleModel(article);
                return View(articleModel);
            }

            _blogService.AddArticle(article);

            return RedirectToAction("Index");
        }

        [HttpGet("Blog/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var article = _blogService.GetArticle(id);

            var articleModel = _blogService.CreateArticleModel(article);

            return View(articleModel);
        }

        [HttpPost("Blog/Edit/{id}")]
        public IActionResult Edit(Article article)
        {
            if (!ModelState.IsValid)
            {
                var articleModel = _blogService.CreateArticleModel(article);
                return View(articleModel);
            }

            _blogService.UpdateArticle(article);

            return RedirectToAction("Index");
        }

        [HttpGet("Blog/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var article = _blogService.GetArticle(id);

            return View(article);
        }

        [HttpPost("Blog/Delete/{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            _blogService.DeleteArticle(id);

            return RedirectToAction("Index");
        }
    }
}
