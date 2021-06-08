namespace TEDinc.MatchInvaders.Unit
{
    public interface IUnitFactory<T> where T : IReadUnitController
    {
        T Next();
    }
}