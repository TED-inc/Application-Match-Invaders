using System;
using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public sealed class EnemyGridController : IUnitsGridController
    {
        public IReadReactiveProperty<int> AliveUnitsCount => aliveCount;
        public int TotalUnitsCount { get; private set; } = 0;

        private readonly IReactiveProperty<int> aliveCount = new ReactivePropertyInt(0);
        private readonly IUnitAtGrid[,] grid;
        private readonly IEnemyUnitParams unitParams;
        

        public void AddUnit(IUnitAtGrid unit)
        {
            if (grid[unit.IndexX, unit.IndexY] != null)
                throw new ArithmeticException("unit already added to this cell");

            grid[unit.IndexX, unit.IndexY] = unit;
            unit.OnDeathFromEffect += OnUnitDeathFromEffect;
            aliveCount.SetWithoutNotify(aliveCount.Value + 1);
            TotalUnitsCount++;
        }

        private void OnUnitDeathFromEffect(IUnitAtGrid unit)
        {
            int availableToKill = unitParams.MaxChindedKill;
            KillNeighbours(unit.IndexX, unit.IndexY);
            UpdateShootingAbility();
            aliveCount.Value -= unitParams.MaxChindedKill - availableToKill + 1;


            void KillNeighbours(int x, int y)
            {
                bool[] isNeigbourSuccesfulyKilled = new[]
                {
                    KillUnit(x + 1, y),
                    KillUnit(x - 1, y),
                    KillUnit(x, y + 1),
                    KillUnit(x, y - 1),
                };
                if (isNeigbourSuccesfulyKilled[0])
                    KillNeighbours(x + 1, y);
                if (isNeigbourSuccesfulyKilled[1])
                    KillNeighbours(x - 1, y);
                if (isNeigbourSuccesfulyKilled[2])
                    KillNeighbours(x, y + 1);
                if (isNeigbourSuccesfulyKilled[3])
                    KillNeighbours(x, y - 1);
            }

            bool KillUnit(int x, int y)
            {
                if (availableToKill <= 0)
                    return false;

                bool isValidPos = x >= 0 && y >= 0 && x < grid.GetLength(0) && y < grid.GetLength(1);
                if (!isValidPos)
                    return false;

                IUnitAtGrid neighbourUnit = grid[x, y];
                if (unit.GroupId != neighbourUnit.GroupId)
                    return false;
                if (neighbourUnit.KillByGrid())
                {
                    availableToKill--;
                    return true;
                }
                return false;
            }
        }

        public void UpdateShootingAbility()
        {
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                bool aliveFound = false;
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    IUnitAtGrid unit = grid[x, y];
                    unit.CanShoot = unit.IsAlive && !aliveFound;
                    aliveFound |= unit.IsAlive;
                }
            }
        }

        public void Reset()
        {
            for (int x = 0; x < grid.GetLength(0); x++)
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    if (grid[x, y] != null)
                        grid[x, y].OnDeathFromEffect -= OnUnitDeathFromEffect;
                    grid[x, y] = null;
                }
            
            aliveCount.SetWithoutNotify(0);
            TotalUnitsCount = 0;
        }

        public EnemyGridController(IEnemyUnitParams unitParams)
        {
            grid = new IUnitAtGrid[unitParams.GridSizeX, unitParams.GridSizeY];
            this.unitParams = unitParams;
        }
    }

    public interface IUnitsGridController
    {
        int TotalUnitsCount { get; }
        IReadReactiveProperty<int> AliveUnitsCount { get; }
        void AddUnit(IUnitAtGrid unit);
        void UpdateShootingAbility();
        void Reset();
    }
}