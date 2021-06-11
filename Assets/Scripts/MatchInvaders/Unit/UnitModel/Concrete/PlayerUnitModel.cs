namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public sealed class PlayerUnitModel : UnitModelBase, IPlayerUnitModel
    {
        public IUnitPostionModel PostionModel => GetSubModel<IUnitPostionModel>(UnitSubModelType.Position);
        public IUnitHealthModel HealthModel => GetSubModel<IUnitHealthModel>(UnitSubModelType.Health);
        public IUnitWeaponModel WeaponModel => GetSubModel<IUnitWeaponModel>(UnitSubModelType.Weapon);
    }

    public interface IPlayerUnitModel : IUnitModel
    {
        IUnitPostionModel PostionModel { get; }
        IUnitHealthModel HealthModel { get; }
        IUnitWeaponModel WeaponModel { get; }
    }
}