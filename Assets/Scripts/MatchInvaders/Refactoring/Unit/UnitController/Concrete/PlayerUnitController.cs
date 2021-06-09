namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public sealed class PlayerUnitController : BaseUnitController
    {
        private readonly IPlayerUnitParams unitParams;

        public override void Update(float deltaTime)
        {
            // TODO: move and shoot
        }

        public PlayerUnitController(IPlayerUnitParams unitParams) =>
            this.unitParams = unitParams;
    }
}