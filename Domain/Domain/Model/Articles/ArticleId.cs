using System;

namespace Domain.Domain.Model.Articles {
    public class ArticleId : IEquatable<ArticleId> {
        public ArticleId(long source)
        {
            Value = source;
        }

        public long Value { get; }

        public bool Equals(ArticleId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ArticleId) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
