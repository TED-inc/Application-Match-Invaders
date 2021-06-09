using TEDinc.MatchInvaders.Effect;

namespace TEDinc.MatchInvaders.Unit
{
    public interface IUnitController : IReadUnitController
    {
        void Setup(IUnitModel unitModel);
    }

    public interface IReadUnitController : IEffectReciverProxy
    {
        IReadUnitModel UnitModel { get; }
        void Update(float deltaTime);
    }
}