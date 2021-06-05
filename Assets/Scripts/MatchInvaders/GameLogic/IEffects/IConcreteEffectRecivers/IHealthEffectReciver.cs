using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.GameLogic
{
    public interface IHealthEffectReciver : IReadHealthEffectReciver, IWriteHealthEffectReciver
    {
        new IReactiveProperty<int> HealthValue { get; }
    }

    public interface IReadHealthEffectReciver : IEffectReciver
    {
        IReadReactiveProperty<int> HealthValue { get; }
    }

    public interface IWriteHealthEffectReciver : IEffectReciver
    {
        IWriteReactiveProperty<int> HealthValue { get; }
    }
}