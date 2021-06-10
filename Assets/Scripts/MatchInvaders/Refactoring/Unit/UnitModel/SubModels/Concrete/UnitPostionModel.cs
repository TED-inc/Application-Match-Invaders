using System;
using UnityEngine;
using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    [Serializable]
    public class UnitPostionModel : IUnitPostionModel
    {
        public IReactiveProperty<Vector2> Position => position;
        IReadReactiveProperty<Vector2> IReadUnitPostionModel.Position => Position;
        [SerializeField]
        private ReactivePropertyVector2 position = new ReactivePropertyVector2(Vector2.zero);

        public UnitPostionModel(Vector2 position) =>
            this.position.Value = position;
    }
}
