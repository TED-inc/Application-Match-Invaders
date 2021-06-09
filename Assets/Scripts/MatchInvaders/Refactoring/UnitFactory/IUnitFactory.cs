using TEDinc.MatchInvaders.Unit;

namespace TEDinc.MatchInvaders.UnitFactory
{
    public interface IUnitFactory<TModel, TController>
        where TModel : IReadUnitModel
        where TController : IReadUnitController
    {
        TController Next();
        TController Next(TModel model);
    }
}