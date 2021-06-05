using TEDinc.MatchInvaders.GameLogic;

namespace TEDinc.MatchInvaders.GameFlow
{
    public interface IUnitController : IEffectReciverProxy
    {
        void Setup(IUnitModel model, IUnitView view);
        void Update(float deltaTime);
    }
}