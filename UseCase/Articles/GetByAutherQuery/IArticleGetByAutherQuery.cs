namespace UseCase.Articles.GetByAutherQuery
{
    public interface IArticleGetByAutherQuery
    {
        ArticleGetByAutherResult ExecuteQuery(ArticleGetByAutherParameter parameter);
    }
}
