using TEDinc.MatchInvaders.Effect;
using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.Unit
{
    public interface IUnitHealthModel : IReadUnitHealthModel, IUnitSubModel, IEffectReciver
    {
        new IReactiveProperty<int> HealthValue { get; }
        new IReactiveProperty<bool> IsAlive { get; }
    }

    public interface IReadUnitHealthModel : IReadUnitSubModel
    {
        IReadReactiveProperty<int> HealthValue { get; }
        IReadReactiveProperty<bool> IsAlive { get; }
    }
}