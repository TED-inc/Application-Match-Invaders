using System;
using UnityEngine;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public abstract class BaseUnitAtGridController : BaseUnitController, IUnitAtGrid
    {
        public event Action<IUnitAtGrid> OnDeathFromEffect = ActionExt.GetNullObject<IUnitAtGrid>();
        public int IndexX { get; private set; }
        public int IndexY { get; private set; }
        public bool CanShoot { get; set; }

        public abstract bool IsAlive { get; }
        public abstract int GroupId { get; }


        protected readonly IUnitsGridController gridController;
        protected readonly Vector2 startPos;


        public abstract bool KillByGrid();
        protected void InvokeOnDeathFromEffect() =>
            OnDeathFromEffect.Invoke(this);

        public BaseUnitAtGridController(IGridParams gridParams, IUnitsGridController gridController, int x, int y)
        {
            this.gridController = gridController;
            IndexX = x;
            IndexY = y;
            startPos = gridParams.CellSize * new Vector2(
                x - (gridParams.GridSizeX - 1) / 2f,
                y - (gridParams.GridSizeY - 1) / 2f);
        }
    }
}