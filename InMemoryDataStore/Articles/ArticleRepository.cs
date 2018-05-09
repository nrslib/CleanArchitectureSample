using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Domain.Model.Articles;
using Domain.Domain.Model.Users;
using MyLibrary.Options;

namespace InMemoryDataStore.Articles {
    public class ArticleRepository : IArticleRepository
    {
        private readonly Dictionary<ArticleId, Article> db = new Dictionary<ArticleId, Article>();

        public Option<Article> Find(ArticleId id)
        {
            if (db.TryGetValue(id, out var article))
            {
                return Option<Article>.Create(article);
            }
            else
            {
                return Option<Article>.None();
            }
        }

        public IEnumerable<Article> FindByAuther(UserId autherId)
        {
            return db.Values.Where(x => x.IsWrittenBy(autherId));
        }

        public void Save(Article article)
        {
            db[article.Id] = article;
        }

        public ArticleId GenerateId()
        {
            var maxId = db.Keys.Aggregate(0L, (acc, id) => Math.Max(acc, id.Value));
            return new ArticleId(maxId + 1);
        }
    }
}
