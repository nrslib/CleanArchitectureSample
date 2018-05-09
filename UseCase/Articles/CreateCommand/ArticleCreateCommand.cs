namespace UseCase.Articles.CreateCommand
{
    public interface IArticleCreateCommand
    {
        void ExecuteCommand(ArticleCreateParameter parameter);
    }
}
