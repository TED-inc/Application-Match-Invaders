using System;
using UnityEngine;
using TEDinc.MatchInvaders.GameLogic;

namespace TEDinc.MatchInvaders.GameFlowOld
{
    public class UnitView : MonoBehaviour, IUnitView
    {
        public event Action<IEffect> OnEffectRecived = ActionExt.GetNullObject<IEffect>();
        public IPositionModel Position => position;
        

        [SerializeReference, HideInInspector]
        private IPositionModel position;

        public void ApplyEffect(IEffect effect) =>
            OnEffectRecived.Invoke(effect);

        public void Destroy() =>
            Destroy(gameObject);

        public void Setup()
        {
            position = new TransformPositionModel(transform);
            transform.localPosition = Vector3.zero;
            position.WorldPosition = transform.position;
        }

        public IUnitView Clone() =>
            Instantiate(this);
    }
}