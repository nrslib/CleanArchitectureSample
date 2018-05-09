using Domain.Application.Articles;
using Domain.Domain.Model.Articles;
using UseCase.Articles.CreateCommand;
using UseCase.Articles.DetailQuery;
using UseCase.Articles.GetByAutherQuery;

namespace Presentation.Services.Article
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public IArticleDetailQuery DetailQuery => new ArticleDetailQuery(articleRepository);
        public IArticleGetByAutherQuery GetByAutherQuery => new ArticleGetByAutherQuery(articleRepository);
        public IArticleCreateCommand CreateCommand => new ArticleCreateCommand(articleRepository);
    }
}
