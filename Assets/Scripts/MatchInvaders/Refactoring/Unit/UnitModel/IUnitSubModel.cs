using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TEDinc.MatchInvaders.Unit
{
    public interface IUnitSubModel : IReadUnitSubModel { }

    public interface IReadUnitSubModel { }

    public enum UnitSubModelType
    {
        Position,
        Health,
        Weapon,
        Group,
    }

    public static class UnitSubModelTypeExt
    {
        private static readonly ReadOnlyDictionary<UnitSubModelType, Type> dict =
            new ReadOnlyDictionary<UnitSubModelType, Type>(
                 new Dictionary<UnitSubModelType, Type>() {
                     { UnitSubModelType.Position, typeof(IReadUnitPostionModel) },
                     { UnitSubModelType.Health, typeof(IReadUnitHealthModel) },
                     { UnitSubModelType.Weapon, typeof(IReadUnitWeaponModel) },
                     { UnitSubModelType.Group, typeof(IReadUnitGroupModel) },
                 });

        public static Type GetModuleType(this UnitSubModelType subModelType) =>
            dict[subModelType];

        public static UnitSubModelType GetModuleType(Type subModelType) =>
            dict.First(p => subModelType.IsAssignableFrom(p.Value)).Key;
    }
}