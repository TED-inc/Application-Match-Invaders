using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    [Serializable]
    public abstract class UnitModelBase : IUnitModel
    {
        [SerializeReference]
        private IUnitSubModel[] subModelsSerialization;
        private Dictionary<UnitSubModelType, IUnitSubModel> subModels;

        public bool ContainsSubModel(UnitSubModelType subModelType) =>
            subModels.ContainsKey(subModelType);

        public T GetSubModel<T>(UnitSubModelType subModelType) where T : IUnitSubModel =>
            (T)subModels[subModelType];

        T IReadUnitModel.GetSubModel<T>(UnitSubModelType subModelType) =>
            (T)subModels[subModelType];

        public void Setup(IUnitSubModel[] subModels)
        {
            if (subModelsSerialization == null)
                subModelsSerialization = subModels;

            this.subModels = subModelsSerialization.ToDictionary(m => UnitSubModelTypeExt.GetModuleType(m.GetType()));
        }
    }
}