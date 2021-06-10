using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.Effect.Concrete
{
    public sealed class FiredEffect : IEffect
    {
        public IReactiveProperty<bool> IsFired { get; private set; }
        IReadReactiveProperty<bool> IReadEffect.IsFired => IsFired;

        public IEffect Clone() =>
            new FiredEffect();

        public FiredEffect()
        {
            IsFired = new ReactiveProperty<bool>(true);
        }
    }
}