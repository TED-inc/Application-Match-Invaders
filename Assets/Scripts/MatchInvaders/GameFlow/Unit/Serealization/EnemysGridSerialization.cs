using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TEDinc.MatchInvaders.GameFlowOld
{
    [Serializable]
    public sealed class EnemysGridSerialization : UnitSerializationBase<EnemyView>
    {
        [SerializeField]
        private LayoutGroup layoutGroup; // TODO: unit must control own position, not by UI components
        [SerializeField]
        private Vector2Int gridSize = new Vector2Int(17, 6);

        private IUnitController[,] unitControllers;

        public override void Setup()
        {
            var factory = new EnemyInstanceFactory(unitParent);
            factory.Setup(unitPrototype);
            unitControllers = new IUnitController[gridSize.x, gridSize.y];

            for (int x = 0; x < unitControllers.GetLength(0); x++)
                for (int y = 0; y < unitControllers.GetLength(1); y++)
                    unitControllers[x, y] = factory.CreateNext();

            CoroutineRunner.instance.StartCoroutine(DisableLayoutGroup());

            IEnumerator DisableLayoutGroup()
            {
                yield return new WaitForEndOfFrame();
                layoutGroup.enabled = false;
            }
        }

        public override void Update(float deltaTime)
        {
            for (int x = 0; x < unitControllers.GetLength(0); x++)
            {
                bool shooterFinded = false;

                for (int y = 0; y < unitControllers.GetLength(1); y++)
                {
                    IUnitController unitController = unitControllers[x, y];
                    if (!shooterFinded && unitController.Model.IsAlive.Value)
                    {
                        shooterFinded = true;
                        (unitController.View as EnemyView).CanShoot = true;
                    }
                    unitController.Update(deltaTime);
                }
            }
        }
    }
}