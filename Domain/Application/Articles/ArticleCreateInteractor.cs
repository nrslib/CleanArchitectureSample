using Domain.Domain.Model.Articles;
using Domain.Domain.Model.Users;
using UseCase.Articles.Create;

namespace Domain.Application.Articles
{
    public class ArticleCreateInteractor : IArticleCreateUseCase
    {
        private readonly IArticleRepository articleRepository;

        public ArticleCreateInteractor(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public ArticleCreateResponse Handle(ArticleCreateRequest request)
        {
            var autherId = new UserId(request.AutherId);
            var id = articleRepository.GenerateId();
            var article = new Article(id, request.Title, request.Body, autherId);
            articleRepository.Save(article);
            return new ArticleCreateResponse(id.Value);
        }
    }
}
