using UnityEngine;
using TEDinc.MatchInvaders.GameFlow;

namespace TEDinc.MatchInvaders.GameLogic
{
    public class PlayerController : UnitControllerBase
    {
        public override void Setup(IUnitModel model, IUnitView view)
        {
            base.Setup(model, view);
            model.Health.MaxHealthValue = GameConst.Player.MaxHealth;
        }

        public override void Update(float deltaTime) =>
            MoveUnit(deltaTime);

        private void MoveUnit(float deltaTime)
        {
            MoveUnit(GetDirectionFromInput());
            UpdateView();


            MoveDirection GetDirectionFromInput()
            {
                if (Input.GetKey(KeyCode.A))
                    return MoveDirection.Left;
                if (Input.GetKey(KeyCode.D))
                    return MoveDirection.Right;

                return MoveDirection.None;
            }

            void MoveUnit(MoveDirection direction) =>
                model.Position.WorldPosition += Vector3.right * (int)direction * GameConst.Player.MoveSpeed * deltaTime;

            void UpdateView() =>
                view.Position.WorldPosition = model.Position.WorldPosition;
        }

        private enum MoveDirection
        {
            None = 0,
            Left = -1,
            Right = 1,
        }
    }
}