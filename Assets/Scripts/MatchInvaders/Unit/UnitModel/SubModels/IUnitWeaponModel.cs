using System;
using UnityEngine;
using TEDinc.MatchInvaders.Effect;
using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.Unit
{
    public interface IUnitWeaponModel : IReadUnitWeaponModel, IUnitSubModel
    {
        new IEffect CurrentEffect { get; }
        void Shoot();
    }

    public interface IReadUnitWeaponModel : IReadUnitSubModel
    {
        IReadEffect CurrentEffect { get; }
        event Action<IEffect> OnSpawnEffect;
    }
}