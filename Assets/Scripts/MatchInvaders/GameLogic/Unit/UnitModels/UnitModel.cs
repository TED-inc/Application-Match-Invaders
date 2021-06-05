using System;
using UnityEngine;

namespace TEDinc.MatchInvaders.GameLogic
{
    [Serializable]
    public abstract class UnitModel<THealthModel> : IUnitModel where THealthModel : IHealthEffectReciver, new()
    {
        public IHealthEffectReciver Health => health;
        IReadHealthEffectReciver IReadUnitModel.Health => health;
        IWriteHealthEffectReciver IWriteUnitModel.Health => health;

        public IPositionModel Position => position;
        IReadPositionModel IReadUnitModel.Position => position;
        IWritePositionModel IWriteUnitModel.Position => position;

        [SerializeReference]
        private IHealthEffectReciver health = new THealthModel();
        [SerializeReference]
        private IPositionModel position = new PositionModel();

        public void ApplyEffect(IEffect effect) =>
            Health.ApplyEffect(effect);
    }
}