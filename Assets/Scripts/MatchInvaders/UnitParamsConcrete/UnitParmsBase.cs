﻿using System;
using UnityEngine;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    [Serializable]
    public abstract class UnitParmsBase : IUnitFactoryParmsBase
    {
        public Transform Parent => parent;
        public UniversalUnitView ViewPrototype => viewPrototype;
        public int Health => health;

        [SerializeField]
        private Transform parent;
        [SerializeField]
        private UniversalUnitView viewPrototype;
        [SerializeField, Min(0)]
        private int health = 3;
    }

    public interface IUnitFactoryParmsBase
    {
        Transform Parent { get; }
        UniversalUnitView ViewPrototype { get; }
        int Health { get; }
    }
}