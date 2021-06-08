namespace TEDinc.MatchInvaders.Unit
{
    public interface IUnitView : IReadUnitView
    {
        void Setup(IReadUnitModel unitModel);
    }

    public interface IReadUnitView
    {
        IReadUnitModel UnitModel { get; }
    }
}