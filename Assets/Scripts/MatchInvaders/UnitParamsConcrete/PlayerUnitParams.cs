using System;
using UnityEngine;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    [Serializable]
    public sealed class PlayerUnitParams : UnitParmsBase, IPlayerUnitParams
    {
        public float Speed => speed;
        public float PositionLimitXAbs => positionLimitXAbs;
        public float MinShootDealy => minShootDealy;
        public IPlayerInput Input => playerInput;


        [SerializeField]
        private float speed = 250f;
        [SerializeField, Min(0f)]
        private float positionLimitXAbs = 900f;
        [SerializeField]
        private float minShootDealy = 0.8f;
        [SerializeField, Min(0f)]
        private PlayerInputKeyboard playerInput;
    }

    public interface IPlayerUnitParams : IUnitFactoryParmsBase
    {
        float Speed { get; } 
        float PositionLimitXAbs { get; }
        float MinShootDealy { get; }
        IPlayerInput Input { get; }
    }
}