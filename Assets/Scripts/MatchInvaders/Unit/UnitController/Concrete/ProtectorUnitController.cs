using System;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public sealed class ProtectorUnitController : BaseUnitAtGridController, IProtectorUnitController
    {
        public override int GroupId => throw new NotImplementedException();
        public override bool IsAlive => unitModel.HealthModel.IsAlive.Value;

        private new IProtectorUnitModel unitModel;

        public override void Update(float deltaTime) { }

        public override void Setup(IUnitModel unitModel)
        {
            base.Setup(unitModel);
            this.unitModel = (IProtectorUnitModel)unitModel;
            this.unitModel.HealthModel.IsAlive.OnChange += OnDeath;
            this.unitModel.PostionModel.Position.Value = startPos;
        }


        public override bool KillByGrid() =>
            throw new NotImplementedException();

        private void OnDeath(bool isAlive)
        {
            if (!isAlive)
            {
                unitModel.HealthModel.IsAlive.OnChange -= OnDeath;
                InvokeOnDeathFromEffect();
            }
        }

        public ProtectorUnitController(IProtectorUnitParams unitParams, int x, int y) : base(unitParams, null, x, y) { }
    }

    public interface IProtectorUnitController : IUnitController, IUnitAtGrid { }
}