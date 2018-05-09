using System;

namespace MyLibrary.Options {
    public class Some<T> : Option<T>
    {
        private readonly T val;

        public Some(T val)
        {
            this.val = val;
        }

        public override TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
        {
            return some(val);
        }

        public override void Match(Action<T> some, Action none)
        {
            some(val);
        }
    }
}
