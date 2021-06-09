using System;
using UnityEngine;
using TEDinc.MatchInvaders.Effect;
using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public class UnitWeaponModel : IUnitWeaponModel
    {
        public IReactiveProperty<Vector2> EffectPosition => throw new NotImplementedException();
        IReadReactiveProperty<Vector2> IReadUnitWeaponModel.EffectPosition => throw new NotImplementedException();

        public event Action<IEffect> OnSpawnEffect = ActionExt.GetNullObject<IEffect>();

        public UnitWeaponModel(IEffect effectPrototype, Vector2 effectSpawnOffset)
        {
            throw new NotImplementedException();
        }
    }
}