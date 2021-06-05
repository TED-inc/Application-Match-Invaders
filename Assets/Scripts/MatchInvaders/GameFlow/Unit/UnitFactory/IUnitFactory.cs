using TEDinc.MatchInvaders.GameLogic;

namespace TEDinc.MatchInvaders.GameFlow
{
    public interface IUnitFactory<TUnitModel, TUnitView> 
        where TUnitModel : IUnitModel
        where TUnitView : IUnitView
    {
        void Setup(TUnitView unitPrototype);

        (TUnitModel model, TUnitView view) CreateNext();
    }
}