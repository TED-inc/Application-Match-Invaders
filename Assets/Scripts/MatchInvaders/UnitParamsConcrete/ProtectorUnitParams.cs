using System;
using UnityEngine;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    [Serializable]
    public class ProtectorUnitParams : UnitParmsBase, IProtectorUnitParams
    {
        public int GridSizeX => gridSize.x;
        public int GridSizeY => gridSize.y;
        public Vector2 CellSize => cellSize;


        [Header("Grid")]
        [SerializeField]
        private Vector2Int gridSize = new Vector2Int(4, 1);
        [SerializeField]
        private Vector2 cellSize = new Vector2(300f, 0f);
    }

    public interface IProtectorUnitParams : IUnitFactoryParmsBase, IGridParams { }
}