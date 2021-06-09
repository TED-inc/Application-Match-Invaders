using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TEDinc.MatchInvaders.Effect;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    [Serializable]
    public abstract class UnitModelBase : IUnitModel
    {
        [SerializeReference]
        private IUnitSubModel[] subModelsSerialization;

        private Dictionary<UnitSubModelType, IUnitSubModel> subModels;
        private IEffectReciver[] effectSubModels;

        public bool ContainsSubModel(UnitSubModelType subModelType) =>
            subModels.ContainsKey(subModelType);

        public T GetSubModel<T>(UnitSubModelType subModelType) where T : IUnitSubModel =>
            (T)subModels[subModelType];

        T IReadUnitModel.GetSubModel<T>(UnitSubModelType subModelType) =>
            (T)subModels[subModelType];

        public IEnumerable<T> GetEffectSubModels<T>() where T : IEffectReciver =>
            (IEnumerable<T>)effectSubModels.GetEnumerator();

        public void Setup(params IUnitSubModel[] subModels)
        {
            if (subModelsSerialization == null)
                subModelsSerialization = subModels;

            this.subModels = subModelsSerialization.ToDictionary(m => UnitSubModelTypeExt.GetModuleType(m.GetType()));
            effectSubModels = subModelsSerialization.Where(m => m.GetType().IsAssignableFrom(typeof(IEffectReciver))).Select(m => (IEffectReciver)m).ToArray();
        }
    }
}