namespace TEDinc.MatchInvaders.GameLogic
{
    public interface IUnitModel : IReadUnitModel, IWriteUnitModel
    {
        new IPositionModel Position { get; }
        new IHealthEffectReciver Health { get; }
    }

    public interface IReadUnitModel : IEffectReciverProxy
    {
        IReadPositionModel Position { get; }
        IReadHealthEffectReciver Health { get; }
    }

    public interface IWriteUnitModel : IEffectReciverProxy
    {
        IWritePositionModel Position { get; }
        IWriteHealthEffectReciver Health { get; }
    }
}