using TEDinc.MatchInvaders.Unit;

namespace TEDinc.MatchInvaders.UnitFactory
{
    public interface IUnitFactory<TModel, TController> : IUnitFactory
        where TModel : IReadUnitModel
        where TController : IReadUnitController
    {
        new TController Next();
        TController Next(TModel model);
    }

    public interface IUnitFactory
    {
        IReadUnitController Next();
        IReadUnitController Next(IReadUnitModel model);
        bool IsComplete();
        void Reset();
    }
}