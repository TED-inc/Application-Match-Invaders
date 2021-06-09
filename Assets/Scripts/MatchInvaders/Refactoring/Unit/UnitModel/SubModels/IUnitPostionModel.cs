using UnityEngine;
using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.Unit
{
    public interface IUnitPostionModel : IReadUnitPostionModel, IUnitSubModel
    {
        new IReactiveProperty<Vector2> Position { get; }
    }

    public interface IReadUnitPostionModel : IReadUnitSubModel
    {
        IReadReactiveProperty<Vector2> Position { get; }
    }
}
