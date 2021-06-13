using TEDinc.MatchInvaders.Effect;
using UnityEngine;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public sealed class EnemyUnitController : BaseUnitAtGridController, IEnemyUnitController
    {
        public override int GroupId => unitModel.GroupModel.GroupId;
        public override bool IsAlive => unitModel.HealthModel.IsAlive.Value;

        private readonly IEnemyUnitGridController enemyGridController;
        private readonly IEnemyUnitParams unitParams;
        private readonly float moveDelay;

        private new IEnemyUnitModel unitModel;
        private bool canBeKilledByGrid = true;
        private float timeFromStartScaled = 0f;

        public override void Update(float deltaTime)
        {
            ShootUpdate(deltaTime);
            UpdateMove();
            timeFromStartScaled += deltaTime * unitParams.SpeedByAlivePercent((float)gridController.AliveUnitsCount.Value / gridController.TotalUnitsCount); ;
        }

        private void ShootUpdate(float deltaTime)
        {
            if (CanShoot
                && enemyGridController.ShootedNotFiredCount < unitParams.MaxBulletCount
                && Random.Range(0f, 1f) <= unitParams.ShootAttemtProbability * deltaTime)
            {
                unitModel.WeaponModel.Shoot();
            }
        }

        private void UpdateMove()
        {
            float moveTime = Mathf.Max(0f, timeFromStartScaled - moveDelay);
            unitModel.PostionModel.Position.Value = 
                startPos
                + unitParams.GetRealtivePosOverTime(moveTime);
        }


        public override void Setup(IUnitModel unitModel)
        {
            base.Setup(unitModel);
            this.unitModel = (IEnemyUnitModel)unitModel;
            this.unitModel.HealthModel.IsAlive.OnChange += OnDeath;
            this.unitModel.WeaponModel.OnSpawnEffect += OnWeaponShooted;
            canBeKilledByGrid = this.unitModel.HealthModel.IsAlive.Value;
        }

        private void OnWeaponShooted(IEffect effect)
        {
            enemyGridController.ShootedNotFiredCount++;
            effect.IsFired.OnChange += OnEffectFired;

            void OnEffectFired(bool isFired)
            {
                enemyGridController.ShootedNotFiredCount--;
                effect.IsFired.OnChange -= OnEffectFired;
            }
        }

        public override bool KillByGrid()
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
                unitModel.WeaponModel.OnSpawnEffect -= OnWeaponShooted;

                if (canBeKilledByGrid)
                {
                    canBeKilledByGrid = false;
                    InvokeOnDeathFromEffect();
                }
            }
        }

        public EnemyUnitController(IEnemyUnitParams unitParams, IEnemyUnitGridController gridController, int x, int y) : base(unitParams, gridController, x, y)
        {
            this.unitParams = unitParams;
            moveDelay = unitParams.MoveStartDelayByLine(y);
            enemyGridController = gridController;
        }
    }

    public interface IEnemyUnitController : IUnitController, IUnitAtGrid { }
}