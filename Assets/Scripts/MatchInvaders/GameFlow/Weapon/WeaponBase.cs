using System;
using UnityEngine;
using TEDinc.MatchInvaders.GameLogic;

namespace TEDinc.MatchInvaders.GameFlow
{
    [Obsolete("TODO : change this class to interface based system")]
    public abstract class WeaponBase : MonoBehaviour
    {
        [SerializeField]
        private PhysicsEffect effectPrototype;
        [SerializeField]
        private Vector3 effectSpawnOffset = new Vector3(0, 10, 0);

        protected virtual IEffect ConstructEffect() => 
            new BulletModel();

        public virtual IEffect Shoot()
        {
            PhysicsEffect physicsEffect = Instantiate(effectPrototype, transform.parent);
            IEffect effect = ConstructEffect();
            physicsEffect.transform.position = transform.position + effectSpawnOffset;
            physicsEffect.SetEffect(effect);
            return effect;
        }
    }
}