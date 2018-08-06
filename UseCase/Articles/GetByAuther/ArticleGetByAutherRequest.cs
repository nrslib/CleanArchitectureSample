using UseCase.Core;

namespace UseCase.Articles.GetByAuther
{
    public class ArticleGetByAutherRequest : IRequest<ArticleGetByAutherResponse>
    {
        public ArticleGetByAutherRequest(long autherId)
        {
            AutherId = autherId;
        }

        public long AutherId { get; }
    }
}
