namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public class EnemyUnitModel : UnitModelBase, IEnemyUnitModel
    {
        public IUnitPostionModel PostionModel => GetSubModel<IUnitPostionModel>(UnitSubModelType.Position);
        public IUnitHealthModel HealthModel => GetSubModel<IUnitHealthModel>(UnitSubModelType.Health);
        public IUnitWeaponModel WeaponModel => GetSubModel<IUnitWeaponModel>(UnitSubModelType.Weapon);
        public IUnitGroupModel GroupModel => GetSubModel<IUnitGroupModel>(UnitSubModelType.Group);
    }

    public interface IEnemyUnitModel : IUnitModel
    {
        IUnitPostionModel PostionModel { get; }
        IUnitHealthModel HealthModel { get; }
        IUnitWeaponModel WeaponModel { get; }
        IUnitGroupModel GroupModel { get; }
    }
}