using UseCase.Core;

namespace UseCase.Articles.GetByAutherQuery
{
    public interface IArticleGetByAutherQuery : IUseCase<ArticleGetByAutherParameter, ArticleGetByAutherResult>
    {
    }
}
