using UseCase.Articles.CreateCommand;
using UseCase.Articles.DetailQuery;
using UseCase.Articles.GetByAutherQuery;

namespace Presentation.Services.Article
{
    public interface IArticleService
    {
        IArticleDetailQuery DetailQuery { get; }
        IArticleGetByAutherQuery GetByAutherQuery { get; }
        IArticleCreateCommand CreateCommand { get; }
    }
}
