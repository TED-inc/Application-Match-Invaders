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

        public int MaxHealthValue 
        { 
            get => maxHealth; 
            set => maxHealth = value; 
        }
        int IReadHealthEffectReciver.MaxHealthValue => maxHealth;
        int IWriteHealthEffectReciver.MaxHealthValue { set => maxHealth = value; }

        [SerializeField]
        private ReactivePropertyInt healthValue = new ReactivePropertyInt();
        [SerializeField]
        private int maxHealth = 1;

        public void ApplyEffect(IEffect effect) =>
            CreateStrategyExecutor(effect).Invoke();

        protected virtual Action CreateStrategyExecutor(IEffect effect)
        {
            if (!effect.IsFired)
            {
                if (effect is IDamageEffect)
                    return () => healthValue.Value -= (effect as IDamageEffect).DamageValue;
            }

            return ActionExt.GetNullObject();
        }

        public void SetupHealthValue(int value)
        {
            maxHealth = value;
            healthValue.SetWithoutNotify(value);
        }
    }
}