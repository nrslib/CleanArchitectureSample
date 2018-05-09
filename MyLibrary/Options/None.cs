using System;

namespace MyLibrary.Options {
    public class None<T>: Option<T> {
        public override TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
        {
            return none();
        }

        public override void Match(Action<T> some, Action none)
        {
            none();
        }
    }
}
