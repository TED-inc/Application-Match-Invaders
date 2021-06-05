using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.GameLogic
{
    public interface IHealthEffectReciver : IReadHealthEffectReciver, IWriteHealthEffectReciver
    {
        new IReactiveProperty<int> HealthValue { get; }
        new int MaxHealthValue { get; set; }
    }

    public interface IReadHealthEffectReciver : IEffectReciver
    {
        IReadReactiveProperty<int> HealthValue { get; }
        int MaxHealthValue { get; }
    }

    public interface IWriteHealthEffectReciver : IEffectReciver
    {
        IWriteReactiveProperty<int> HealthValue { get; }
        int MaxHealthValue { set; }
        void SetupHealthValue(int value);
    }
}