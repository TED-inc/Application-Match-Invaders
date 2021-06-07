using System;

namespace TEDinc.Utils.ReactiveProperty
{
    [Serializable]
    public sealed class ReactivePropertyInt : ReactiveProperty<int> { }

    [Serializable]
    public sealed class ReactivePropertyBool : ReactiveProperty<bool> { }

    [Serializable]
    public sealed class ReactivePropertyFloat : ReactiveProperty<float> { }

    [Serializable]
    public sealed class ReactivePropertyString : ReactiveProperty<string> { }
}