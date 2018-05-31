using MyLibrary.Options;
using UseCase.Articles.Common;
using UseCase.Core;

namespace UseCase.Articles.DetailQuery
{
    public class ArticleDetailResult : IResponse
    {
        public ArticleDetailResult(Option<ArticleDto> article) {
            Article = article;
        }

        public Option<ArticleDto> Article { get; }
    }
}
