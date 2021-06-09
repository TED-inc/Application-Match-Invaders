using System;
using UnityEngine;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    [Serializable]
    public abstract class UnitParmsBase : IUnitFactoryParmsBase
    {
        public Transform Parent => parent;
        public UniversalUnitView ViewPrototype => viewPrototype;

        [SerializeField]
        private Transform parent;
        [SerializeField]
        private UniversalUnitView viewPrototype;
    }

    public interface IUnitFactoryParmsBase
    {
        Transform Parent { get; }
        UniversalUnitView ViewPrototype { get; }
    }
}