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

        public void ExecuteCommand(ArticleCreateParameter parameter)
        {
            var autherId = new UserId(parameter.AutherId);
            var id = articleRepository.GenerateId();
            var article = new Article(id, parameter.Title, parameter.Body, autherId);
            articleRepository.Save(article);
        }
    }
}
