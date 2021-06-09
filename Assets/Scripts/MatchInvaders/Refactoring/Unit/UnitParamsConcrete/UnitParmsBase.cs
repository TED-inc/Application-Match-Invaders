using System;
using UnityEngine;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    [Serializable]
    public abstract class UnitParmsBase : IUnitFactoryBaseParms
    {
        public Transform Parent => parent;
        public UniversalUnitView ViewPrototype => viewPrototype;

        [SerializeField]
        private Transform parent;
        [SerializeField]
        private UniversalUnitView viewPrototype;
    }

    public interface IUnitFactoryBaseParms
    {
        Transform Parent { get; }
        UniversalUnitView ViewPrototype { get; }
    }
}