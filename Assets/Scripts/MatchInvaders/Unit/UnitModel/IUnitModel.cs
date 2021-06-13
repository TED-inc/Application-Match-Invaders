using System.Collections.Generic;
using TEDinc.MatchInvaders.Effect;

namespace TEDinc.MatchInvaders.Unit
{
    public interface IUnitModel : IReadUnitModel
    {
        void Setup(params IUnitSubModel[] subModels);
        new T GetSubModel<T>(UnitSubModelType subModelType) where T : IUnitSubModel;
    }

    public interface IReadUnitModel
    {
        T GetSubModel<T>(UnitSubModelType subModelType) where T : IReadUnitSubModel;
        bool ContainsSubModel(UnitSubModelType subModelType);
        IEnumerable<T> GetEffectSubModels<T>() where T : IEffectReciver;
    }
}