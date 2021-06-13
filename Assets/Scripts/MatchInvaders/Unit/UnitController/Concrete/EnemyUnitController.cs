using System;
using TEDinc.MatchInvaders.Effect;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public sealed class EnemyUnitController : BaseUnitController, IEnemyUnitController
    {
        public event Action<IUnitAtGrid> OnDeathFromEffect = ActionExt.GetNullObject<IUnitAtGrid>();
        public int GroupId => unitModel.GroupModel.GroupId;
        public bool IsAlive => unitModel.HealthModel.IsAlive.Value;
        public int IndexX { get; private set; }
        public int IndexY { get; private set; }
        public bool CanShoot { get; set; }

        private static int shootedCount = 0;

        private readonly IEnemyUnitParams unitParams;
        private readonly IUnitsGridController gridController;

        private readonly Vector2 startPos;
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
                && shootedCount < unitParams.MaxBulletCount
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
            canBeKilledByGrid = this.unitModel.HealthModel.IsAlive.Value;
            this.unitModel.WeaponModel.OnSpawnEffect += OnWeaponShooted;
        }

        private void OnWeaponShooted(IEffect effect)
        {
            shootedCount++;
            effect.IsFired.OnChange += OnEffectFired;

            void OnEffectFired(bool isFired)
            {
                shootedCount--;
                effect.IsFired.OnChange -= OnEffectFired;
            }
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
                unitModel.WeaponModel.OnSpawnEffect -= OnWeaponShooted;

                if (canBeKilledByGrid)
                {
                    canBeKilledByGrid = false;
                    OnDeathFromEffect.Invoke(this);
                }
            }
        }

        public EnemyUnitController(IEnemyUnitParams unitParams, IUnitsGridController gridController, int x, int y)
        {
            this.unitParams = unitParams;
            this.gridController = gridController;
            IndexX = x;
            IndexY = y;
            startPos = unitParams.CellSize * new Vector2(x - unitParams.GridSizeX / 2f, y - unitParams.GridSizeY / 2f);
            moveDelay = unitParams.MoveStartDelayByLine(y);
        }
    }

    public interface IEnemyUnitController : IUnitController, IUnitAtGrid { }

    public interface IUnitAtGrid
    {
        event Action<IUnitAtGrid> OnDeathFromEffect;
        bool IsAlive { get; }
        int IndexX { get; }
        int IndexY { get; }
        bool CanShoot { get; set; }
        int GroupId { get; }
        bool KillByGrid();
    }
}