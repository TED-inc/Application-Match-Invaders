using UnityEngine;
using TEDinc.MatchInvaders.Unit;
using TEDinc.MatchInvaders.Unit.Concrete;

namespace TEDinc.MatchInvaders.UnitFactory.Concrete
{
    public sealed class ProtectorUnitFactory : IUnitFactory<IProtectorUnitModel, IProtectorUnitController>
    {
        private readonly IProtectorUnitParams unitParams;
        private int spawnedCount = 0;

        public IProtectorUnitController Next()
        {
            IProtectorUnitModel model = new ProtectorUnitModel();
            model.Setup(
                new UnitPostionModel(Vector2.zero),
                new UnitHealthModel(unitParams.Health));
            return Next(model);
        }

        public IProtectorUnitController Next(IProtectorUnitModel model)
        {
            IProtectorUnitController controller = new ProtectorUnitController(
                unitParams, 
                spawnedCount % unitParams.GridSizeX, 
                spawnedCount / unitParams.GridSizeX);
            spawnedCount++;
            controller.Setup(model);
            GameObject.Instantiate(unitParams.ViewPrototype, unitParams.Parent).Setup(model, controller);
            return controller;
        }



        IReadUnitController IUnitFactory.Next() =>
            Next();
        IReadUnitController IUnitFactory.Next(IReadUnitModel model) =>
            Next(model as IProtectorUnitModel);

        public bool IsComplete() =>
            spawnedCount >= unitParams.GridSizeX * unitParams.GridSizeY;

        public void Reset() =>
            spawnedCount = 0;


        public ProtectorUnitFactory(IProtectorUnitParams unitParams) =>
            this.unitParams = unitParams;
    }
}