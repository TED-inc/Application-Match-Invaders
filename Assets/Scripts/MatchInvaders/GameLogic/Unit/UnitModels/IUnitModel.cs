using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.GameLogic
{
    public interface IUnitModel : IReadUnitModel, IWriteUnitModel
    {
        new IPositionModel Position { get; }
        new IHealthEffectReciver Health { get; }
        new IReactiveProperty<bool> IsAlive { get; }
    }

    public interface IReadUnitModel : IEffectReciverProxy
    {
        IReadPositionModel Position { get; }
        IReadHealthEffectReciver Health { get; }
        IReadReactiveProperty<bool> IsAlive { get; }
    }

    public interface IWriteUnitModel : IEffectReciverProxy
    {
        IWritePositionModel Position { get; }
        IWriteHealthEffectReciver Health { get; }
        IWriteReactiveProperty<bool> IsAlive { get; }
    }
}