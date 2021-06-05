using System;
using UnityEngine;

namespace TEDinc.MatchInvaders.GameLogic
{
    public class UnitView : MonoBehaviour, IUnitView
    {
        public event Action<IEffect> OnEffectRecived = ActionExt.GetNullObject<IEffect>();
        public IPositionModel Position => positionModel;
        

        [SerializeReference, HideInInspector]
        private IPositionModel positionModel;

        public void ApplyEffect(IEffect effect) =>
            OnEffectRecived.Invoke(effect);

        public void Destroy() =>
            Destroy(gameObject);

        public void Setup() =>
            positionModel = new TransformPositionModel(transform);
    }
}