using TEDinc.MatchInvaders.Effect;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public abstract class BaseUnitController : IUnitController
    {
        IReadUnitModel IReadUnitController.UnitModel => unitModel;
        protected IUnitModel unitModel { get; private set; }

        public void ApplyEffect(IEffect effect)
        {
            foreach (IEffectReciver effectReciver in unitModel.GetEffectSubModels<IEffectReciver>())
                effectReciver.ApplyEffect(effect);
        }

        public virtual void Setup(IUnitModel unitModel) =>
            this.unitModel = unitModel;

        public abstract void Update(float deltaTime);
    }
}