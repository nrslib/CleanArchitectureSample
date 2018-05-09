namespace Domain.Domain.Model.Articles {
    public interface IArticleDataTransformer<T>
    {
        void Id(long id);
        void Title(string title);
        void Body(string body);
        T Build();
    }
}
