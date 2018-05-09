namespace UseCase.Articles.DetailQuery
{
    public class ArticleDetailParameter
    {
        public ArticleDetailParameter(long articleId)
        {
            ArticleId = articleId;
        }

        public long ArticleId { get; }
    }
}
