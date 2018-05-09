using System.Collections.Generic;
using System.Linq;
using UseCase.Articles.Common;

namespace Presentation.Models.Article {
    public class ArticleListModel {
        public ArticleListModel(IEnumerable<ArticleDto> articles)
        {
            Rows = articles.Select(x => new ArticleListRow(x)).ToArray();
        }

        public ArticleListRow[] Rows { get; }
    }

    public class ArticleListRow
    {
        public ArticleListRow(ArticleDto source)
        {
            Id = source.Id;
            Title = source.Title;
        }

        public long Id { get; }
        public string Title { get; }
    }
}