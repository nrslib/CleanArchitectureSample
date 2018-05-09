using System.Collections.Generic;
using Domain.Domain.Model.Users;
using MyLibrary.Options;

namespace Domain.Domain.Model.Articles {
    public interface IArticleRepository
    {
        Option<Article> Find(ArticleId id);
        IEnumerable<Article> FindByAuther(UserId autherId);
        void Save(Article article);
        ArticleId GenerateId();
    }
}
