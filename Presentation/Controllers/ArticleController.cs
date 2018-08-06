using Microsoft.AspNetCore.Mvc;
using Presentation.Libs.Exceptions;
using Presentation.Models.Article;
using UseCase.Articles.Common;
using UseCase.Articles.Create;
using UseCase.Articles.GetDetail;
using UseCase.Articles.GetByAuther;
using UseCase.Core.Bus;

namespace Presentation.Controllers
{
    public class ArticleController : Controller
    {
        private readonly UseCaseBus bus;

        public ArticleController(UseCaseBus bus)
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
            var parameter = new ArticleCreateRequest(model.Title, model.Body, myId());
            var response = bus.Handle(parameter);

            // You shoud return generated id from service or defivary notification object, if you wanna redirect to detail.
            return RedirectToAction("MyList");
        }

        public ActionResult MyList()
        {
            var parameter = new ArticleGetByAutherRequest(myId());
            var response = bus.Handle(parameter);
            var listViewModel = new ArticleListModel(response.Articles);
            return View(listViewModel);
        }

        public ActionResult Detail(long? id) {
            if (!id.HasValue) {
                return RedirectToAction("MyList");
            }
            var articleId = id.Value;
            var parameter = new ArticleGetDetailRequest(articleId);
            var response = bus.Handle(parameter);
            var optArticle = response.Article;
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