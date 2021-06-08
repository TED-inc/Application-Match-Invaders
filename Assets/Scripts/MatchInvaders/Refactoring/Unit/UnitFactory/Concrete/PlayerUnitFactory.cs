namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public class PlayerUnitFactory : IUnitFactory<PlayerUnitController>
    {
        public PlayerUnitController Next()
        {
            PlayerUnitController unitController = new PlayerUnitController();
            unitController.Setup(new PlayerUnitModel(), null);
            return unitController;
        }
    }
}