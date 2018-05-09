using System;

namespace MyLibrary.Options {
    public abstract class Option<T>
    {
        public static Option<T> Create(T val)
        {
            return new Some<T>(val);
        }

        public static Option<T> None()
        {
            return new None<T>();
        }

        public abstract TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none);
        public abstract void Match(Action<T> some, Action none);
    }
}
