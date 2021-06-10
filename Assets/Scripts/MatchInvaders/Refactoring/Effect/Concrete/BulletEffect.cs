using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.Effect.Concrete
{
    public sealed class BulletEffect : IDamageEffect
    {
        public int DamageValue { get; private set; }
        public IReactiveProperty<bool> IsFired { get; private set; } = new ReactivePropertyBool();
        IReadReactiveProperty<bool> IReadEffect.IsFired => IsFired;

        public IEffect Clone() =>
            new BulletEffect(DamageValue);

        public BulletEffect(int damageValue = 1) =>
            DamageValue = damageValue;
    }
}