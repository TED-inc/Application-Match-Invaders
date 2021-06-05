using System;
using UnityEngine;

namespace TEDinc.MatchInvaders.GameLogic
{
    [Serializable]
    public sealed class BulletModel : IDamageEffect
    {
        public int DamageValue => damageValue;

        [SerializeField]
        private int damageValue;

        public BulletModel(int damageValue = 1)
        {
            this.damageValue = damageValue;
        }
    }
}