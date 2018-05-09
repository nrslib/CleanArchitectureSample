namespace UseCase.Articles.CreateCommand
{
    public class ArticleCreateParameter
    {
        public ArticleCreateParameter(string title, string body, long autherId) {
            Title = title;
            Body = body;
            AutherId = autherId;
        }

        public string Title { get; }
        public string Body { get; }
        public long AutherId { get; }
    }
}
