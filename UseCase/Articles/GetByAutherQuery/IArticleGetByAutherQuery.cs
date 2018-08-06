using UseCase.Core;

namespace UseCase.Articles.GetByAutherQuery
{
    public interface IArticleGetByAutherUseCase : IUseCase<ArticleGetByAutherRequest, ArticleGetByAutherResult>
    {
    }
}
