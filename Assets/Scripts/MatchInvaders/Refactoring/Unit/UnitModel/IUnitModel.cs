namespace TEDinc.MatchInvaders.Unit
{
    public interface IUnitModel : IReadUnitModel
    {
        void Setup(IUnitSubModel[] subModels);
        new T GetSubModel<T>() where T : IUnitSubModel;
    }

    public interface IReadUnitModel
    {
        T GetSubModel<T>() where T : IReadUnitSubModel;
        bool ContainsSubModel<T>() where T : IReadUnitSubModel;
    }
}