using TEDinc.MatchInvaders.GameFlow;

namespace TEDinc.MatchInvaders.GameLogic
{
    public abstract class UnitControllerBase : IUnitController
    {
        protected IUnitModel model { get; private set; }
        protected IUnitView view { get; private set; }

        public virtual void Setup(IUnitModel model, IUnitView view)
        {
            this.model = model;
            this.view = view;
            model.Position.WorldPosition = view.Position.WorldPosition;
        }

        public virtual void Update(float deltaTime) { }

        void IEffectReciver.ApplyEffect(IEffect effect) =>
            model.ApplyEffect(effect);
    }
}