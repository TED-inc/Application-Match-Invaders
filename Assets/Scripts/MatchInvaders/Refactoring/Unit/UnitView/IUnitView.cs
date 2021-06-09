using TEDinc.MatchInvaders.Effect;

namespace TEDinc.MatchInvaders.Unit
{
    public interface IUnitView : IReadUnitView
    {
        void Setup(IReadUnitModel unitModel, IReadUnitController unitController);
    }

    public interface IReadUnitView : IEffectReciverProxy
    {
        IReadUnitModel UnitModel { get; }
        IReadUnitController UnitController { get; }
    }
}