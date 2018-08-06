using UseCase.Core;

namespace UseCase.Articles.GetDetail
{
    public class ArticleGetDetailRequest : IRequest<ArticleGetDetailResponse>
    {
        public ArticleGetDetailRequest(long articleId)
        {
            ArticleId = articleId;
        }

        public long ArticleId { get; }
    }
}
