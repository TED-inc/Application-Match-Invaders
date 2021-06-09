using TEDinc.MatchInvaders.GameFlowOld;

namespace TEDinc.MatchInvaders.GameLogic
{
    public class EnemyController : UnitControllerBase, IEnemyGroupElement
    {
        public override void Setup(IUnitModel model, IUnitView view)
        {
            base.Setup(model, view);
            model.Health.SetupHealthValue(GameConst.Enemy.MaxHealth);
        }

        public void SetGroup(int index)
        {
            foreach (object item in new object []{ model, view })
                if (item is IEnemyGroupElement)
                    (item as IEnemyGroupElement).SetGroup(index);
        }
    }

    public interface IEnemyGroupElement
    {
        void SetGroup(int index);
    }
}
