namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public sealed class ProtectorUnitModel : UnitModelBase, IProtectorUnitModel
    {
        public IUnitPostionModel PostionModel => GetSubModel<IUnitPostionModel>(UnitSubModelType.Position);
        public IUnitHealthModel HealthModel => GetSubModel<IUnitHealthModel>(UnitSubModelType.Health);
    }
    
    public interface IProtectorUnitModel : IUnitModel
    {
        IUnitPostionModel PostionModel { get; }
        IUnitHealthModel HealthModel { get; }
    }
}
