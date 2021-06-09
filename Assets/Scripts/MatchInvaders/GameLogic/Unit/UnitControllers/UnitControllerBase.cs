using TEDinc.MatchInvaders.GameFlowOld;

namespace TEDinc.MatchInvaders.GameLogic
{
    public abstract class UnitControllerBase : IUnitController
    {
        public IReadUnitModel Model => model;
        public IUnitView View => view;

        protected IUnitModel model { get; private set; }
        protected IUnitView view { get; private set; }

        public virtual void Setup(IUnitModel model, IUnitView view)
        {
            this.model = model;
            this.view = view;
            model.Position.WorldPosition = view.Position.WorldPosition;
            model.IsAlive.OnChange += (value) => { if (!value) view.Destroy(); };
            view.OnEffectRecived += model.ApplyEffect;
        }

        public virtual void Update(float deltaTime) { }

        void IEffectReciver.ApplyEffect(IEffect effect) =>
            model.ApplyEffect(effect);
    }
}