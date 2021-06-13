using System;

namespace TEDinc.MatchInvaders.Unit
{
    public interface IUnitAtGrid
    {
        event Action<IUnitAtGrid> OnDeathFromEffect;
        bool IsAlive { get; }
        int IndexX { get; }
        int IndexY { get; }
        bool CanShoot { get; set; }
        int GroupId { get; }
        bool KillByGrid();
    }
}