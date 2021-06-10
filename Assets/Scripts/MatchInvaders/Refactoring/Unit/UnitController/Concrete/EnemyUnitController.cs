using System;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public sealed class EnemyUnitController : BaseUnitController, IEnemyUnitController
    {
        public event Action<IUnitAtGrid> OnDeathFromEffect = ActionExt.GetNullObject<IUnitAtGrid>();
        public int GroupId => unitModel.GroupModel.GroupId;
        public int IndexX { get; private set; }
        public int IndexY { get; private set; }
        public bool CanShoot { get; private set; }

        private readonly IEnemyUnitParams unitParams;
        private new IEnemyUnitModel unitModel;
        private bool canBeKilledByGrid = true;

        public override void Update(float deltaTime)
        {
            // TODO : move and shoot
        }

        public override void Setup(IUnitModel unitModel)
        {
            base.Setup(unitModel);
            this.unitModel = (IEnemyUnitModel)unitModel;
            this.unitModel.HealthModel.IsAlive.OnChange += OnDeath;
            canBeKilledByGrid = this.unitModel.HealthModel.IsAlive.Value;
        }

        bool IUnitAtGrid.KillByGrid()
        {
            if (!canBeKilledByGrid)
                return false;

            canBeKilledByGrid = false;
            unitModel.HealthModel.HealthValue.Value = 0;
            return true;
        }

        private void OnDeath(bool isAlive)
        {
            if (!isAlive)
            {
                unitModel.HealthModel.IsAlive.OnChange -= OnDeath;

                if (canBeKilledByGrid)
                {
                    canBeKilledByGrid = false;
                    OnDeathFromEffect.Invoke(this);
                }
            }
        }

        public EnemyUnitController(IEnemyUnitParams unitParams, int x, int y)
        {
            this.unitParams = unitParams;
            IndexX = x;
            IndexY = y;
        }
    }

    public interface IEnemyUnitController : IUnitController, IUnitAtGrid { }

    public interface IUnitAtGrid
    {
        event Action<IUnitAtGrid> OnDeathFromEffect;
        int IndexX { get; }
        int IndexY { get; }
        bool CanShoot { get; }
        int GroupId { get; }
        bool KillByGrid();
    }
}