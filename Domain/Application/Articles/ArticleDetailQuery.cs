using Domain.Domain.Model.Articles;
using MyLibrary.Options;
using UseCase.Articles.Common;
using UseCase.Articles.DetailQuery;

namespace Domain.Application.Articles {
    public class ArticleDetailQuery : IArticleDetailQuery {
        private readonly IArticleRepository articleRepository;

        public ArticleDetailQuery(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public ArticleDetailResult GetDetail(ArticleDetailParameter parameter)
        {
            var articleId = new ArticleId(parameter.ArticleId);
            var article = articleRepository.Find(articleId);
            var transformer = new ArticleToDtoTransformer();
            var dto = article.Match(x => Option<ArticleDto>.Create(x.Transform(transformer)), Option<ArticleDto>.None);
            return new ArticleDetailResult(dto);
        }
    }
}
