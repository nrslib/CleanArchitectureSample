using MyLibrary.Options;
using UseCase.Articles.Common;

namespace UseCase.Articles.DetailQuery
{
    public class ArticleDetailResult
    {
        public ArticleDetailResult(Option<ArticleDto> article) {
            Article = article;
        }

        public Option<ArticleDto> Article { get; }
    }
}
