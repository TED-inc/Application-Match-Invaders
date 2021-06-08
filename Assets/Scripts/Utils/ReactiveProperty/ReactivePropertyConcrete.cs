using System;
using UnityEngine;

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

    [Serializable]
    public sealed class ReactivePropertyVector2 : ReactiveProperty<Vector2> { }

    [Serializable]
    public sealed class ReactivePropertyVector3 : ReactiveProperty<Vector3> { }
}