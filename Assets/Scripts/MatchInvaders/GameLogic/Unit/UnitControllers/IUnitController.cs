using TEDinc.MatchInvaders.GameLogic;

namespace TEDinc.MatchInvaders.GameFlow
{
    public interface IUnitController : IEffectReciverProxy
    {
        IReadUnitModel Model { get; }
        IUnitView View { get; }
        void Setup(IUnitModel model, IUnitView view);
        void Update(float deltaTime);
    }
}