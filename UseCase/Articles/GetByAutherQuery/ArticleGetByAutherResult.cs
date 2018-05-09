using System.Collections.Generic;
using System.Linq;
using UseCase.Articles.Common;

namespace UseCase.Articles.GetByAutherQuery
{
    public class ArticleGetByAutherResult
    {
        public ArticleGetByAutherResult(IEnumerable<ArticleDto> articles)
        {
            Articles = articles.ToArray();
        }

        public ArticleDto[] Articles { get; }
    }
}
