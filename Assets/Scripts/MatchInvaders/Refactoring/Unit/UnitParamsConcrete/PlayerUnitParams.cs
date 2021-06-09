using System;
using UnityEngine;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    [Serializable]
    public sealed class PlayerUnitParams : UnitParmsBase, IPlayerUnitParams
    {
        public int Health => health;
        public float Speed => speed;
        public float PositionLimitXAbs => positionLimitXAbs;

        [SerializeField]
        private int health = 3;
        [SerializeField]
        private float speed = 250;
        [SerializeField]
        private float positionLimitXAbs = 900;
    }

    public interface IPlayerUnitParams : IUnitFactoryBaseParms
    {
        int Health { get; }
        float Speed { get; } 
        float PositionLimitXAbs { get; }
    }
}