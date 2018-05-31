using UseCase.Core;

namespace UseCase.Articles.DetailQuery
{
    public class ArticleDetailParameter : IRequest<ArticleDetailResult>
    {
        public ArticleDetailParameter(long articleId)
        {
            ArticleId = articleId;
        }

        public long ArticleId { get; }
    }
}
