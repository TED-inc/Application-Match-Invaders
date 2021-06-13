using UnityEngine;
using TEDinc.MatchInvaders.Unit;
using TEDinc.MatchInvaders.Unit.Concrete;
using TEDinc.MatchInvaders.Effect.Concrete;
using TEDinc.MatchInvaders.GameFlow;

namespace TEDinc.MatchInvaders.UnitFactory.Concrete
{
    public sealed class PlayerUnitFactory : IUnitFactory<IPlayerUnitModel, IPlayerUnitController>
    {
        private readonly IPlayerUnitParams unitParams;
        private readonly ILevelResultSystem levelResultSystem;
        private bool isPlayerSpawned = false;

        public IPlayerUnitController Next()
        {
            IPlayerUnitModel model = new PlayerUnitModel();
            model.Setup(
                new UnitPostionModel(Vector2.zero),
                new UnitWeaponModel(new BulletEffect()),
                new UnitHealthModel(unitParams.Health));
            return Next(model);
        }

        public IPlayerUnitController Next(IPlayerUnitModel model)
        {
            isPlayerSpawned = true;
            IPlayerUnitController controller = new PlayerUnitController(unitParams);
            model.HealthModel.IsAlive.OnChange += (b) => levelResultSystem.FailLevel();
            controller.Setup(model);
            GameObject.Instantiate(unitParams.ViewPrototype, unitParams.Parent).Setup(model, controller);
            return controller;
        }

        IReadUnitController IUnitFactory.Next() =>
            Next();

        IReadUnitController IUnitFactory.Next(IReadUnitModel model) =>
            Next(model as IPlayerUnitModel);

        public bool IsComplete() =>
            isPlayerSpawned;

        public void Reset() =>
            isPlayerSpawned = false;

        public PlayerUnitFactory(IPlayerUnitParams unitParams, ILevelResultSystem levelResultSystem)
        {
            this.unitParams = unitParams;
            this.levelResultSystem = levelResultSystem;
        }
    }
}