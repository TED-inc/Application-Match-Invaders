namespace TEDinc.MatchInvaders.Unit
{
    public interface IUnitController : IReadUnitController
    {
        void Setup(IUnitModel UnitModel, IUnitView unitView);
    }

    public interface IReadUnitController
    {
        IReadUnitModel UnitModel { get; }
        IReadUnitView UnitView { get; }
        void Update(float deltaTime);
    }
}