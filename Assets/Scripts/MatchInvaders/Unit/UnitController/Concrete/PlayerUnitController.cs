using UnityEngine;
using TEDinc.MatchInvaders.Effect;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public sealed class PlayerUnitController : BaseUnitController, IPlayerUnitController
    {
        private readonly IPlayerUnitParams unitParams;
        private new IPlayerUnitModel unitModel;
        private float shootTimer;

        public override void Update(float deltaTime)
        {
            UpdateMove(deltaTime);
            ShootUpdate(deltaTime);
        }

        private void UpdateMove(float deltaTime)
        {
            Vector2 newPos = unitModel.PostionModel.Position.Value
                + Vector2.right
                * unitParams.Input.GetHorizontalInput()
                * deltaTime * unitParams.Speed;
            float xPos = Mathf.Clamp(newPos.x, -unitParams.PositionLimitXAbs, unitParams.PositionLimitXAbs);
            newPos.x = xPos;
            unitModel.PostionModel.Position.Value = newPos;
        }

        private void ShootUpdate(float deltaTime)
        {
            if (unitParams.MinShootDealy <= shootTimer && unitParams.Input.GetShootInput())
                unitModel.WeaponModel.Shoot();
            shootTimer += deltaTime;
        }

        public override void Setup(IUnitModel unitModel)
        {
            base.Setup(unitModel);
            this.unitModel = (IPlayerUnitModel)unitModel;
            this.unitModel.WeaponModel.OnSpawnEffect += ResetShootTimer;
        }

        private void ResetShootTimer(IEffect effect) =>
            shootTimer = 0f;

        public PlayerUnitController(IPlayerUnitParams unitParams) =>
            this.unitParams = unitParams;
    }

    public interface IPlayerUnitController : IUnitController { }
}