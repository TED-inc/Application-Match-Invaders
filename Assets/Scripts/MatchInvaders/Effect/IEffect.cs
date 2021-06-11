using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.Effect
{
    public interface IEffect : IReadEffect
    { 
        new IReactiveProperty<bool> IsFired { get; }
        IEffect Clone();
    }

    public interface IReadEffect
    {
        IReadReactiveProperty<bool> IsFired { get; }
    }
}