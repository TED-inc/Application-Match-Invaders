using UnityEngine;
using TEDinc.MatchInvaders.Unit;
using TEDinc.MatchInvaders.Unit.Concrete;
using TEDinc.MatchInvaders.Effect.Concrete;

namespace TEDinc.MatchInvaders.UnitFactory.Concrete
{
    public sealed class PlayerUnitFactory : IUnitFactory<PlayerUnitModel, PlayerUnitController>
    {
        private readonly IPlayerUnitParams unitParams;

        public PlayerUnitController Next()
        {
            PlayerUnitModel model = new PlayerUnitModel();
            model.Setup(new UnitPostionModel(Vector2.zero), new UnitWeaponModel(new BulletEffect()));
            return Next(model);
        }

        public PlayerUnitController Next(PlayerUnitModel model)
        {
            PlayerUnitController controller = new PlayerUnitController(unitParams);
            controller.Setup(model);
            GameObject.Instantiate(unitParams.ViewPrototype, unitParams.Parent).Setup(model, controller);
            return controller;
        }

        IReadUnitController IUnitFactory.Next() =>
            Next();

        IReadUnitController IUnitFactory.Next(IReadUnitModel model) =>
            Next(model as PlayerUnitModel);

        public PlayerUnitFactory(IPlayerUnitParams unitParams) =>
            this.unitParams = unitParams;
    }
}