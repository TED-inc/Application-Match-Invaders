using System;
using UnityEngine;
using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.GameLogic
{
    [Serializable]
    public class HealthModel : IHealthEffectReciver
    {
        public IReactiveProperty<int> HealthValue => healthValue;
        IReadReactiveProperty<int> IReadHealthEffectReciver.HealthValue => healthValue;
        IWriteReactiveProperty<int> IWriteHealthEffectReciver.HealthValue => healthValue;

        [SerializeField]
        private ReactivePropertyInt healthValue = new ReactivePropertyInt();

        public void ApplyEffect(IEffect effect) =>
            CreateStrategyExecutor(effect).Invoke();

        protected virtual Action CreateStrategyExecutor(IEffect effect)
        {
            if (effect is IDamageEffect)
                return () => healthValue.Value -= (effect as IDamageEffect).DamageValue;

            return ActionExt.GetNullObject();
        }
    }
}