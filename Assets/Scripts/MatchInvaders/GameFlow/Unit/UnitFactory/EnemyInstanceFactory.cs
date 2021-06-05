using System;
using UnityEngine;
using TEDinc.MatchInvaders.GameLogic;
using Random = System.Random;

namespace TEDinc.MatchInvaders.GameFlow
{
    public class EnemyInstanceFactory : IUnitFactory<EnemyView, EnemyController>
    {
        private Transform unitParent;
        private EnemyView unitPrototype;
        private Random random;

        public void Setup(EnemyView unitPrototype)
        {
            this.unitPrototype = unitPrototype;
            random = new Random();
        }

        public EnemyController CreateNext()
        {
            EnemyController controller = new EnemyController();
            EnemyView view = (EnemyView)unitPrototype.Clone();
            view.transform.SetParent(unitParent);
            view.Setup();
            controller.Setup(new EnemyModel(), view);
            controller.SetGroup(random.Next(0, GameConst.Enemy.GroupCount));
            return controller;
        }

        public EnemyInstanceFactory(Transform unitParent) =>
            this.unitParent = unitParent;
    }
}