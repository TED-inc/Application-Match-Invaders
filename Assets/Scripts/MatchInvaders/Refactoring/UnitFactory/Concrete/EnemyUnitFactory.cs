using System.Collections;
using UnityEngine;
using TEDinc.MatchInvaders.Unit;
using TEDinc.MatchInvaders.Unit.Concrete;
using TEDinc.MatchInvaders.Effect.Concrete;
using Random = System.Random;

namespace TEDinc.MatchInvaders.UnitFactory.Concrete
{
    public sealed class EnemyUnitFactory : IUnitFactory<IEnemyUnitModel, IEnemyUnitController>
    {
        private readonly Random random = new Random();
        private readonly IUnitsGridController unitsGridController;
        private readonly IEnemyUnitParams unitParams;
        private int spawnedCount = 0;

        public IEnemyUnitController Next()
        {
            IEnemyUnitModel model = new EnemyUnitModel();
            model.Setup(
                new UnitPostionModel(Vector2.zero),
                new UnitWeaponModel(new BulletEffect()),
                new UnitGroupModel(random.Next(0, unitParams.GroupCount)),
                new UnitHealthModel(unitParams.Health));
            return Next(model);
        }

        public IEnemyUnitController Next(IEnemyUnitModel model)
        {
            IEnemyUnitController controller = new EnemyUnitController(unitParams, spawnedCount % unitParams.GridSizeX, spawnedCount / unitParams.GridSizeX);
            spawnedCount++;
            controller.Setup(model);
            GameObject.Instantiate(unitParams.ViewPrototype, unitParams.Parent).Setup(model, controller);
            unitsGridController.AddUnit(controller);
            return controller;
        }



        IReadUnitController IUnitFactory.Next() =>
            Next();
        IReadUnitController IUnitFactory.Next(IReadUnitModel model) =>
            Next(model as IEnemyUnitModel);

        public bool IsComplete()
        {
            CoroutineRunner.Instance.StartCoroutine(DisableGridLayout());
            return spawnedCount >= unitParams.GridSizeX * unitParams.GridSizeY;

            IEnumerator DisableGridLayout()
            {
                yield return new WaitForEndOfFrame();
                unitParams.GridLayout.enabled = false;
            }
        }
        public void Reset()
        {
            spawnedCount = 0;
            unitParams.GridLayout.enabled = true;
        }


        public EnemyUnitFactory(IUnitsGridController unitsGridController, IEnemyUnitParams unitParams)
        {
            unitParams.GridLayout.enabled = true;
            this.unitsGridController = unitsGridController;
            this.unitParams = unitParams;
        }
    }
}