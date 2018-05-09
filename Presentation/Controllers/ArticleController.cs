using Microsoft.AspNetCore.Mvc;
using Presentation.Libs.Exceptions;
using Presentation.Models.Article;
using Presentation.Services.Article;
using UseCase.Articles.Common;
using UseCase.Articles.CreateCommand;
using UseCase.Articles.DetailQuery;
using UseCase.Articles.GetByAutherQuery;

namespace Presentation.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService bus;

        public ArticleController(IArticleService bus)
        {
            this.bus = bus;
        }

        public ActionResult Index() {
            return View();
        }

        public ActionResult Add() {
            return View();
        }

        [HttpPost]
        public ActionResult AddConfirm(ArticleAddModel model)
        {
            var parameter = new ArticleCreateParameter(model.Title, model.Body, myId());
            var command = bus.CreateCommand;
            command.ExecuteCommand(parameter);
            
            // You shoud return generated id from service or defivary notification object, if you wanna redirect to detail.
            return RedirectToAction("MyList");
        }

        public ActionResult MyList()
        {
            var parameter = new ArticleGetByAutherParameter(myId());
            var query = bus.GetByAutherQuery;
            var result = query.ExecuteQuery(parameter);
            var listViewModel = new ArticleListModel(result.Articles);
            return View(listViewModel);
        }

        public ActionResult Detail(long? id) {
            if (!id.HasValue) {
                return RedirectToAction("MyList");
            }
            var articleId = id.Value;
            var parameter = new ArticleDetailParameter(articleId);
            var query = bus.DetailQuery;
            var detailResult = query.GetDetail(parameter);
            var optArticle = detailResult.Article;
            var article = optArticle.Match(
                x => new ArticleDto(x.Id, x.Title, x.Body),
                () => throw new TargetIdNotFoundException(articleId)
            );

            return View(article);
        }

        // Temporary implementation
        private long myId() {
            return 1;
        }
    }
}