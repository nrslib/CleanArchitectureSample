namespace UseCase.Articles.GetByAutherQuery
{
    public class ArticleGetByAutherParameter
    {
        public ArticleGetByAutherParameter(long autherId)
        {
            AutherId = autherId;
        }

        public long AutherId { get; }
    }
}
