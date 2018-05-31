using UseCase.Core;

namespace UseCase.Articles.CreateCommand
{
    public interface IArticleCreateCommand : IUseCase<ArticleCreateParameter, ArticleCreateResponse>
    {
    }
}
