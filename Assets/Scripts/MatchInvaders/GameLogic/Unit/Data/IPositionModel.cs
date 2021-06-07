using UnityEngine;

namespace TEDinc.MatchInvaders.GameLogic
{
    public interface IPositionModel : IReadPositionModel, IWritePositionModel
    {
        new Vector3 WorldPosition { get; set; }
    }

    public interface IReadPositionModel
    {
        Vector3 WorldPosition { get; }
    }

    public interface IWritePositionModel
    {
        Vector3 WorldPosition { set; }
    }
}