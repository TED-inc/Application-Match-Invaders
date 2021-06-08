using System;
using UnityEngine;

namespace TEDinc.Utils.ReactiveProperty
{
    [Serializable]
    public class ReactiveProperty<T> : IReactiveProperty<T> where T : IEquatable<T>
    {
        public T Value
        {
            get => value;
            set
            {
                if (!this.value.Equals(value)) // not equal
                {
                    this.value = value;
                    OnChange.Invoke(Value);
                }
            }
        }

        [SerializeField]
        private T value;

        public event Action<T> OnChange = ActionExt.GetNullObject<T>();

        public void SetWithoutNotify(T value) =>
            this.value = value;

        public static implicit operator T(ReactiveProperty<T> instance) =>
            instance.value;

        public ReactiveProperty() { }

        public ReactiveProperty(T value) =>
            SetWithoutNotify(value);
    }
}