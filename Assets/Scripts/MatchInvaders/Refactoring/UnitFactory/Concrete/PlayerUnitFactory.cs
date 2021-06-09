using UnityEngine;
using TEDinc.MatchInvaders.Unit.Concrete;

namespace TEDinc.MatchInvaders.UnitFactory.Concrete
{
    public sealed class PlayerUnitFactory : IUnitFactory<PlayerUnitModel, PlayerUnitController>
    {
        private readonly IPlayerUnitParams unitParams;

        public PlayerUnitController Next()
        {
            PlayerUnitModel model = new PlayerUnitModel();
            // TODO: model.Setup();
            return Next();
        }

        public PlayerUnitController Next(PlayerUnitModel model)
        {
            PlayerUnitController controller = new PlayerUnitController(unitParams);
            controller.Setup(model);
            GameObject.Instantiate(unitParams.ViewPrototype, unitParams.Parent).Setup(model, controller);
            return controller;
        }

        public PlayerUnitFactory(IPlayerUnitParams unitParams) =>
            this.unitParams = unitParams;
    }
}