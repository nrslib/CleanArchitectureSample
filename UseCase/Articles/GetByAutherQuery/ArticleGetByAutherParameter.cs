using UseCase.Core;

namespace UseCase.Articles.GetByAutherQuery
{
    public class ArticleGetByAutherRequest : IRequest<ArticleGetByAutherResult>
    {
        public ArticleGetByAutherRequest(long autherId)
        {
            AutherId = autherId;
        }

        public long AutherId { get; }
    }
}
