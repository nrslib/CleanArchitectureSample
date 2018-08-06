using UseCase.Core;

namespace UseCase.Articles.Create
{
    public class ArticleCreateResponse : IResponse
    {
        public ArticleCreateResponse(long createdArticleId)
        {
            CreatedArticleId = createdArticleId;
        }

        public long CreatedArticleId { get; }
    }
}
