using UseCase.Core;

namespace UseCase.Articles.GetByAutherQuery
{
    public class ArticleGetByAutherParameter : IRequest<ArticleGetByAutherResult>
    {
        public ArticleGetByAutherParameter(long autherId)
        {
            AutherId = autherId;
        }

        public long AutherId { get; }
    }
}
