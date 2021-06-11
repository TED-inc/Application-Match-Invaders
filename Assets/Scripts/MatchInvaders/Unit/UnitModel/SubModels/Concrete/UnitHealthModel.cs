using System;
using UnityEngine;
using TEDinc.MatchInvaders.Effect;
using TEDinc.MatchInvaders.Effect.Concrete;
using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    [Serializable]
    public class UnitHealthModel : IUnitHealthModel
    {
        public IReactiveProperty<int> HealthValue => healthValue;
        public IReactiveProperty<bool> IsAlive => isAlive;
        IReadReactiveProperty<int> IReadUnitHealthModel.HealthValue => HealthValue;
        IReadReactiveProperty<bool> IReadUnitHealthModel.IsAlive => IsAlive;

        [SerializeReference]
        private IReactiveProperty<int> healthValue;
        [SerializeReference]
        private IReactiveProperty<bool> isAlive;

        public void ApplyEffect(IEffect effect) =>
            CreateStrategyExecutor(effect).Invoke();

        protected virtual Action CreateStrategyExecutor(IEffect effect)
        {
            if (!effect.IsFired.Value)
            {
                if (effect is IDamageEffect)
                    return () => healthValue.Value -= (effect as IDamageEffect).DamageValue;
            }

            return ActionExt.GetNullObject();
        }

        private void ChekAlive(int healthValue)
        {
            isAlive.Value = healthValue > 0;
            if (!isAlive.Value)
                this.healthValue.OnChange -= ChekAlive;
        }

        public UnitHealthModel(int healthValue)
        {
            isAlive = new ReactivePropertyBool(healthValue > 0);
            this.healthValue = new ReactivePropertyInt(healthValue);
            this.healthValue.OnChange += ChekAlive;
        }
    }
}