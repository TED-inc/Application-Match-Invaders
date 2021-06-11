using UnityEngine;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public sealed class PlayerUnitController : BaseUnitController, IPlayerUnitController
    {
        private readonly IPlayerUnitParams unitParams;
        private new IPlayerUnitModel unitModel;

        public override void Update(float deltaTime)
        {
            UpdateMove(deltaTime);
            ShootUpdate();
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

        private void ShootUpdate()
        {
            if (unitParams.Input.GetShootInput())
                unitModel.WeaponModel.Shoot();
        }

        public override void Setup(IUnitModel unitModel)
        {
            base.Setup(unitModel);
            this.unitModel = (IPlayerUnitModel)unitModel;
        }

        public PlayerUnitController(IPlayerUnitParams unitParams) =>
            this.unitParams = unitParams;
    }

    public interface IPlayerUnitController : IUnitController { }
}