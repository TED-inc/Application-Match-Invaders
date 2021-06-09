namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public sealed class PlayerUnitModel : UnitModelBase
    {
        public IReadUnitPostionModel PostionModel => GetSubModel<IUnitPostionModel>(UnitSubModelType.Position);
        public IReadUnitHealthModel HealthModel => GetSubModel<IUnitHealthModel>(UnitSubModelType.Health);
        public IReadUnitWeaponModel WeaponModel => GetSubModel<IUnitWeaponModel>(UnitSubModelType.Weapon);
    }
}