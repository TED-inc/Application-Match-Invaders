namespace TEDinc.MatchInvaders.GameLogic
{
    public interface IUnitController : IEffectReciverProxy
    {
        void Setup(IUnitModel model, IUnitView view);
        void Update(float deltaTime);
    }
}