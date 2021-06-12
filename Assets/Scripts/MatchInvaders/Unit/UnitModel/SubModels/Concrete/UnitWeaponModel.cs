using System;
using UnityEngine;
using TEDinc.MatchInvaders.Effect;
using TEDinc.MatchInvaders.Effect.Concrete;
using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public sealed class UnitWeaponModel : IUnitWeaponModel
    {
        public event Action<IEffect> OnSpawnEffect = ActionExt.GetNullObject<IEffect>();
        public IEffect CurrentEffect { get; private set; } = new FiredEffect();
        IReadEffect IReadUnitWeaponModel.CurrentEffect => CurrentEffect;

        private readonly IEffect effectPrototype;

        public void Shoot()
        {
            if (CurrentEffect.IsFired.Value)
            {
                CurrentEffect = effectPrototype.Clone();
                OnSpawnEffect.Invoke(CurrentEffect);
            }
        }

        public UnitWeaponModel(IEffect effectPrototype)
        {
            this.effectPrototype = effectPrototype;
        }
    }
}