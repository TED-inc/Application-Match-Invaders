using UnityEngine;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public sealed class PlayerUnitController : BaseUnitController
    {
        private readonly IPlayerUnitParams unitParams;
        private new IPlayerUnitModel unitModel;

        public override void Update(float deltaTime)
        {
            // TODO: shoot
            UpdateMove(deltaTime);
        }

        private void UpdateMove(float deltaTime)
        {
            int moveDirection =
                Input.GetKey(unitParams.MoveLeft) ? -1 :
                Input.GetKey(unitParams.MoveRight) ? 1 :
                0;

            Vector2 newPos = unitModel.PostionModel.Position.Value + Vector2.right * moveDirection * deltaTime * unitParams.Speed;
            float xPos = Mathf.Clamp(newPos.x, -unitParams.PositionLimitXAbs, unitParams.PositionLimitXAbs);
            newPos.x = xPos;
            unitModel.PostionModel.Position.Value = newPos;
        }

        public override void Setup(IUnitModel unitModel)
        {
            base.Setup(unitModel);
            this.unitModel = (IPlayerUnitModel)unitModel;
        }

        public PlayerUnitController(IPlayerUnitParams unitParams) =>
            this.unitParams = unitParams;
    }
}