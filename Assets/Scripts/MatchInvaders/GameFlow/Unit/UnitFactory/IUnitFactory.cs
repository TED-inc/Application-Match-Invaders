using TEDinc.MatchInvaders.GameLogic;

namespace TEDinc.MatchInvaders.GameFlow
{
    public interface IUnitFactory<TUnitView, TUnitController> 
        where TUnitController : IUnitController
        where TUnitView : IUnitView
    {
        void Setup(TUnitView unitPrototype);

        TUnitController CreateNext();
    }
}