using Domain.Domain.Model.Articles;
using Domain.Domain.Model.Users;
using UseCase.Articles.CreateCommand;

namespace Domain.Application.Articles
{
    public class ArticleCreateCommand : IArticleCreateCommand
    {
        private readonly IArticleRepository articleRepository;

        public ArticleCreateCommand(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public ArticleCreateResponse Handle(ArticleCreateParameter request)
        {
            var autherId = new UserId(request.AutherId);
            var id = articleRepository.GenerateId();
            var article = new Article(id, request.Title, request.Body, autherId);
            articleRepository.Save(article);
            return new ArticleCreateResponse(id.Value);
        }
    }
}
