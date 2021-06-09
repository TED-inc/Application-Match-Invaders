using System;
using UnityEngine;
using TEDinc.MatchInvaders.GameLogic;

namespace TEDinc.MatchInvaders.GameFlowOld
{
    public sealed class PlayerWeapon : WeaponBase
    {
        private IEffect currentEffect;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space) && (currentEffect == null || currentEffect.IsFired))
                currentEffect = Shoot();
        }
    }
}