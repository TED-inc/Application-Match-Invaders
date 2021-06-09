using TEDinc.MatchInvaders.Effect;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public abstract class BaseUnitController : IUnitController
    {
        public IReadUnitModel UnitModel { get; private set; }

        public void ApplyEffect(IEffect effect)
        {
            foreach (IEffectReciver effectReciver in UnitModel.GetEffectSubModels<IEffectReciver>())
                effectReciver.ApplyEffect(effect);
        }

        public void Setup(IUnitModel unitModel) =>
            UnitModel = unitModel;

        public abstract void Update(float deltaTime);
    }
}