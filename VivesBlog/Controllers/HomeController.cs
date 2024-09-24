using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VivesBlog.Model;
using VivesBlog.Core;
using VivesBlog.Service;

namespace VivesBlog.Controllers
{
    public class HomeController : Controller
	{
		private readonly PeopleService _peopleService;
        private readonly BlogService _blogService;

        public HomeController()
		{
            _peopleService = new PeopleService();
            _blogService = new BlogService();
        }


		public IActionResult Index()
		{
			var articles = _blogService.GetArticles();
            return View(articles);
		}

		public IActionResult Details(int id)
		{
			var article = _blogService.GetArticle(id);

            return View(article);
		}
	}
}
