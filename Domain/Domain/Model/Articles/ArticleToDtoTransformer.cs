using UseCase.Articles.Common;

namespace Domain.Domain.Model.Articles {
    public class ArticleToDtoTransformer : IArticleDataTransformer<ArticleDto>
    {
        private long id;
        private string title;
        private string body;

        public void Id(long id)
        {
            this.id = id;
        }

        public void Title(string title)
        {
            this.title = title;
        }

        public void Body(string body)
        {
            this.body = body;
        }

        public ArticleDto Build()
        {
            return new ArticleDto(id, title, body);
        }
    }
}
