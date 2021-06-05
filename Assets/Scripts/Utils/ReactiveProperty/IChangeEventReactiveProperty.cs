using System;

namespace TEDinc.Utils.ReactiveProperty
{
    public interface IChangeEventReactiveProperty<T>
    {
        event Action<T> OnChange;
    }
}
