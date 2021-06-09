using System;
using UnityEngine;
using TEDinc.MatchInvaders.GameLogic;

namespace TEDinc.MatchInvaders.GameFlowOld
{
    [Serializable]
    public abstract class UnitSerializationBase<TUnitView> : IUnitSerialization
         where TUnitView : Component, IUnitView
    {
        [SerializeField]
        protected TUnitView unitPrototype;
        [SerializeField]
        protected Transform unitParent;

        public abstract void Setup();
        public abstract void Update(float deltaTime);

        protected virtual void CreateInstance(IUnitController playerController, IUnitModel model)
        {
            TUnitView view = (TUnitView)unitPrototype.Clone(); // TODO: cashe instance
            view.transform.parent = unitParent;
            view.Setup();
            playerController.Setup(model, view);
        }
    }
}