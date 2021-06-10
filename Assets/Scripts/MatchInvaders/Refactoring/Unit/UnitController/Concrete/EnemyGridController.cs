namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public sealed class EnemyGridController : IUnitsGridController
    {
        private readonly IUnitAtGrid[,] grid;

        public void AddUnit(IUnitAtGrid unit)
        {
            grid[unit.IndexX, unit.IndexY] = unit;
            unit.OnDeathFromEffect += OnUnitDeathFromEffect;
        }

        private void OnUnitDeathFromEffect(IUnitAtGrid unit)
        {
            // TODO: kill group
        }

        public EnemyGridController(IEnemyUnitParams unitParams) =>
            grid = new IUnitAtGrid[unitParams.GridSizeX, unitParams.GridSizeY];
    }

    public interface IUnitsGridController
    {
        void AddUnit(IUnitAtGrid unit);
    }
}