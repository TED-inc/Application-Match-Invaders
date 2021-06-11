using System;
using UnityEngine;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    [Serializable]
    public sealed class PlayerUnitParams : UnitParmsBase, IPlayerUnitParams
    {
        public float Speed => speed;
        public float PositionLimitXAbs => positionLimitXAbs;
        public IPlayerInput Input => playerInput;

        [SerializeField]
        private float speed = 250;
        [SerializeField, Min(0)]
        private float positionLimitXAbs = 900;
        [SerializeField]
        private PlayerInputKeyboard playerInput;
    }

    public interface IPlayerUnitParams : IUnitFactoryParmsBase
    {
        float Speed { get; } 
        float PositionLimitXAbs { get; }
        IPlayerInput Input { get; }
    }
}