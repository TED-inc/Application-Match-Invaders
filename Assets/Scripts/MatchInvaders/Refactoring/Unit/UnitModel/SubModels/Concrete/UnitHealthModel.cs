using TEDinc.MatchInvaders.Effect;
using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public class UnitHealthModel : IUnitHealthModel
    {
        public IReactiveProperty<int> HealthValue => throw new System.NotImplementedException();

        public IReactiveProperty<bool> IsAlive => throw new System.NotImplementedException();

        IReadReactiveProperty<int> IReadUnitHealthModel.HealthValue => throw new System.NotImplementedException();

        IReadReactiveProperty<bool> IReadUnitHealthModel.IsAlive => throw new System.NotImplementedException();

        public void ApplyEffect(IEffect effect)
        {
            throw new System.NotImplementedException();
        }

        public UnitHealthModel(int healthValue)
        {
            throw new System.NotImplementedException();
        }
    }
}