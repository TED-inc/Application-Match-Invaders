using UnityEngine;
using TEDinc.MatchInvaders.GameLogic;

namespace TEDinc.MatchInvaders.GameFlow
{
    public sealed class UnitInstanceFactory<TUnitView> : IUnitFactory<EnemyModel, TUnitView>
        where TUnitView : Object, IUnitView
    {
        private TUnitView unitPrototype;

        public void Setup(TUnitView unitPrototype) =>
            this.unitPrototype = unitPrototype;

        public (EnemyModel model, TUnitView view) CreateNext() =>
             (new EnemyModel(), (TUnitView)unitPrototype.Clone());
    }
}