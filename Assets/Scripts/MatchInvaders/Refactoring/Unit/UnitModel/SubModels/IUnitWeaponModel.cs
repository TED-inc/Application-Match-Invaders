using System;
using UnityEngine;
using TEDinc.MatchInvaders.Effect;
using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.Unit
{
    public interface IUnitWeaponModel : IReadUnitWeaponModel, IUnitSubModel
    {
        new IReactiveProperty<Vector2> EffectPosition { get; }
        void Setup(IEffect effectPrototype, Vector2 effectSpawnOffset);
    }

    public interface IReadUnitWeaponModel : IReadUnitSubModel
    {
        IReadReactiveProperty<Vector2> EffectPosition { get; }
        event Action<IEffect> OnSpawnEffect;
    }
}