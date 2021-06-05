using System;
using UnityEngine;

namespace TEDinc.MatchInvaders.GameLogic
{
    [Serializable]
    public class PlayerController : IUnitController
    {
        [SerializeReference]
        private IUnitModel model;
        [SerializeReference]
        private IUnitView view;

        public void Setup(IUnitModel model, IUnitView view)
        {
            this.model = model;
            this.view = view;
            model.Health.MaxHealthValue = GameConst.Player.MaxHealth;
            model.Position.WorldPosition = view.Position.WorldPosition;
        }

        public void Update(float deltaTime) =>
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

        void IEffectReciver.ApplyEffect(IEffect effect) =>
            model.ApplyEffect(effect);
    }
}