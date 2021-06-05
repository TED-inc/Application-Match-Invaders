using System;
using TEDinc.Utils.ReactiveProperty;
using UnityEngine;

namespace TEDinc.MatchInvaders.GameLogic
{
    [Serializable]
    public abstract class UnitModel<THealthModel> : IUnitModel
        where THealthModel : IHealthEffectReciver, new()
    {
        public IHealthEffectReciver Health => health;
        IReadHealthEffectReciver IReadUnitModel.Health => Health;
        IWriteHealthEffectReciver IWriteUnitModel.Health => Health;

        public IPositionModel Position => position;
        IReadPositionModel IReadUnitModel.Position => Position;
        IWritePositionModel IWriteUnitModel.Position => Position;

        public IReactiveProperty<bool> IsAlive => isAlive;
        IReadReactiveProperty<bool> IReadUnitModel.IsAlive => IsAlive;
        IWriteReactiveProperty<bool> IWriteUnitModel.IsAlive => IsAlive;

        [SerializeReference]
        private IHealthEffectReciver health = new THealthModel();
        [SerializeReference]
        private IPositionModel position = new PositionModel();
        [SerializeField]
        private ReactivePropertyBool isAlive = new ReactivePropertyBool();

        public void ApplyEffect(IEffect effect) =>
            Health.ApplyEffect(effect);

        public UnitModel()
        {
            isAlive.SetWithoutNotify(true);
            health.HealthValue.OnChange += (value) => isAlive.Value = value > 0;
        }
    }
}