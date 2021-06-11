﻿using System;
using UnityEngine;
using TEDinc.MatchInvaders.Effect;
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
        private new IEnemyUnitModel unitModel;
        private bool canBeKilledByGrid = true;

        public override void Update(float deltaTime)
        {
            // TODO : move
            ShootUpdate(deltaTime);
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
        bool IsAlive { get; }
        int IndexX { get; }
        int IndexY { get; }
        bool CanShoot { get; set; }
        int GroupId { get; }
        bool KillByGrid();
    }
}