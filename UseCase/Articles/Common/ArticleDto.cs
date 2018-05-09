namespace UseCase.Articles.Common{
    public class ArticleDto {
        public ArticleDto(long articleId, string title, string body)
        {
            Id = articleId;
            Title = title;
            Body = body;
        }

        public long Id { get; }
        public string Title { get; }
        public string Body { get; }
    }
}
