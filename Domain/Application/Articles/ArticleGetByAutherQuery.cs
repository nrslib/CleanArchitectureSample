using System.Linq;
using Domain.Domain.Model.Articles;
using Domain.Domain.Model.Users;
using UseCase.Articles.GetByAutherQuery;

namespace Domain.Application.Articles
{
    public class ArticleGetByAutherQuery : IArticleGetByAutherQuery
    {
        private readonly IArticleRepository articleRepository;

        public ArticleGetByAutherQuery(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public ArticleGetByAutherResult Handle(ArticleGetByAutherParameter request)
        {
            var autherId = new UserId(request.AutherId);
            var articles = articleRepository.FindByAuther(autherId);
            var transformer = new ArticleToDtoTransformer();
            var articleDtos = articles.Select(x => x.Transform(transformer));
            var dto = new ArticleGetByAutherResult(articleDtos);
            return dto;
        }
    }
}
