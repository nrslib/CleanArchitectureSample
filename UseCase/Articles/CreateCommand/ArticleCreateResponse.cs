using UseCase.Core;

namespace UseCase.Articles.CreateCommand
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
