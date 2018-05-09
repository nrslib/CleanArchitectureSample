namespace UseCase.Articles.DetailQuery
{
    public interface IArticleDetailQuery
    {
        ArticleDetailResult GetDetail(ArticleDetailParameter parameter);
    }
}
