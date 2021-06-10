using System;
using UnityEngine;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    [Serializable]
    public sealed class PlayerUnitParams : UnitParmsBase, IPlayerUnitParams
    {
        public float Speed => speed;
        public float PositionLimitXAbs => positionLimitXAbs;
        public KeyCode KeyMoveLeft => KeyCode.A;
        public KeyCode KeyMoveRight => KeyCode.D;
        public KeyCode KeyShoot => KeyCode.Space;

        [SerializeField]
        private float speed = 250;
        [SerializeField, Min(0)]
        private float positionLimitXAbs = 900;
    }

    public interface IPlayerUnitParams : IUnitFactoryParmsBase
    {
        float Speed { get; } 
        float PositionLimitXAbs { get; }
        KeyCode KeyMoveLeft { get; }
        KeyCode KeyMoveRight { get; }
        KeyCode KeyShoot { get; }
    }
}