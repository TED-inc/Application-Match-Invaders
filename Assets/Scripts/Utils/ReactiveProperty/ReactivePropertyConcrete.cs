using System;
using UnityEngine;

namespace TEDinc.Utils.ReactiveProperty
{
    [Serializable]
    public sealed class ReactivePropertyInt : ReactiveProperty<int> 
    {
        public ReactivePropertyInt(int value) : base(value) { }
    }

    [Serializable]
    public sealed class ReactivePropertyBool : ReactiveProperty<bool> 
    {
        public ReactivePropertyBool(bool value) : base(value) { }
    }

    [Serializable]
    public sealed class ReactivePropertyFloat : ReactiveProperty<float> 
    {
        public ReactivePropertyFloat(float value) : base(value) { }
    }

    [Serializable]
    public sealed class ReactivePropertyString : ReactiveProperty<string> 
    {
        public ReactivePropertyString(string value) : base(value) { }
    }

    [Serializable]
    public sealed class ReactivePropertyVector2 : ReactiveProperty<Vector2> 
    {
        public ReactivePropertyVector2(Vector2 value) : base(value) { }
    }

    [Serializable]
    public sealed class ReactivePropertyVector3 : ReactiveProperty<Vector3> 
    {
        public ReactivePropertyVector3(Vector3 value) : base(value) { }
    }
}