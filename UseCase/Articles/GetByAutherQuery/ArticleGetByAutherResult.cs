using System.Collections.Generic;
using System.Linq;
using UseCase.Articles.Common;
using UseCase.Core;

namespace UseCase.Articles.GetByAutherQuery
{
    public class ArticleGetByAutherResult : IResponse
    {
        public ArticleGetByAutherResult(IEnumerable<ArticleDto> articles)
        {
            Articles = articles.ToArray();
        }

        public ArticleDto[] Articles { get; }
    }
}
