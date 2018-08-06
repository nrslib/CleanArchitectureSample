using Domain.Domain.Model.Articles;
using MyLibrary.Options;
using UseCase.Articles.Common;
using UseCase.Articles.GetDetail;

namespace Domain.Application.Articles {
    public class ArticleDetailGetInteractor : IArticleGetDetailUseCase {
        private readonly IArticleRepository articleRepository;

        public ArticleDetailGetInteractor(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public ArticleGetDetailResponse Handle(ArticleGetDetailRequest request)
        {
            var articleId = new ArticleId(request.ArticleId);
            var article = articleRepository.Find(articleId);
            var transformer = new ArticleToDtoTransformer();
            var dto = article.Match(x => Option<ArticleDto>.Create(x.Transform(transformer)), Option<ArticleDto>.None);
            return new ArticleGetDetailResponse(dto);
        }
    }
}
