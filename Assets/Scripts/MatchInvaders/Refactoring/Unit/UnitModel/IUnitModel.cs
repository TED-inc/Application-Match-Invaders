namespace TEDinc.MatchInvaders.Unit
{
    public interface IUnitModel : IReadUnitModel
    {
        void Setup(IUnitSubModel[] subModels);
        new T GetSubModel<T>(UnitSubModelType subModelType) where T : IUnitSubModel;
    }

    public interface IReadUnitModel
    {
        T GetSubModel<T>(UnitSubModelType subModelType) where T : IReadUnitSubModel;
        bool ContainsSubModel(UnitSubModelType subModelType);
    }
}