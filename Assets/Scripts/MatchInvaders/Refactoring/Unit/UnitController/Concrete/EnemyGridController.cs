namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public sealed class EnemyGridController : IUnitsGridController
    {
        private readonly IUnitAtGrid[,] grid;
        private readonly IEnemyUnitParams unitParams;

        public void AddUnit(IUnitAtGrid unit)
        {
            grid[unit.IndexX, unit.IndexY] = unit;
            unit.OnDeathFromEffect += OnUnitDeathFromEffect;
        }

        private void OnUnitDeathFromEffect(IUnitAtGrid unit)
        {
            int availableToKill = unitParams.MaxChindedKill;
            KillNeighbours(unit.IndexX, unit.IndexY);

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

        public void Reset()
        {
            foreach (IUnitAtGrid unit in grid)
                unit.OnDeathFromEffect -= OnUnitDeathFromEffect;
        }

        public EnemyGridController(IEnemyUnitParams unitParams)
        {
            grid = new IUnitAtGrid[unitParams.GridSizeX, unitParams.GridSizeY];
            this.unitParams = unitParams;
        }
    }

    public interface IUnitsGridController
    {
        void AddUnit(IUnitAtGrid unit);
        void Reset();
    }
}