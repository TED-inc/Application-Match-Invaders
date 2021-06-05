namespace TEDinc.MatchInvaders.GameLogic
{
    public interface IUnitModel : IReadUnitModel, IWriteUnitModel
    {
        new IPositionModel Position { get; }
    }

    public interface IReadUnitModel : IEffectReciverProxy
    {
        IReadPositionModel Position { get; }
        IReadHealthEffectReciver Health { get; }
    }

    public interface IWriteUnitModel : IEffectReciverProxy
    {
        IWritePositionModel Position { get; }
    }
}