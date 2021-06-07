using System;
using UnityEngine;
using TEDinc.MatchInvaders.GameFlow;

namespace TEDinc.MatchInvaders.GameLogic
{
    [Serializable]
    public sealed class BulletModel : IDamageEffect
    {
        public int DamageValue => damageValue;
        public bool IsFired { get; set; }

        [SerializeField]
        private int damageValue;

        public BulletModel(int damageValue = 1)
        {
            this.damageValue = damageValue;
        }

        public IEffect Clone()
        {
            throw new NotImplementedException();
        }

        public void SetPhysics(Vector3 position)
        {
            throw new NotImplementedException();
        }
    }
}