namespace TEDinc.Utils.ReactiveProperty
{
    public interface IReactiveProperty<T> : IReadReactiveProperty<T>, IWriteReactiveProperty<T>
    {
        new T Value { get; set; }
    }

    public interface IWriteReactiveProperty<T> : IChangeEventReactiveProperty<T>
    {
        T Value { set; }
        void SetWithoutNotify(T value);
    }

    public interface IReadReactiveProperty<T> : IChangeEventReactiveProperty<T>
    {
        T Value { get; }
    }
}