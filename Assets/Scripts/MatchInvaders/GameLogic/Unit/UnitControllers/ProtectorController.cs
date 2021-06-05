using TEDinc.MatchInvaders.GameFlow;

namespace TEDinc.MatchInvaders.GameLogic
{
    public class ProtectorController : UnitControllerBase 
    {
        public override void Setup(IUnitModel model, IUnitView view)
        {
            base.Setup(model, view);
            model.Health.SetupHealthValue(GameConst.Protector.MaxHealth);
        }
    }
}