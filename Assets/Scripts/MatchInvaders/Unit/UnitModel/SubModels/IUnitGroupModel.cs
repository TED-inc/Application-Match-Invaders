namespace TEDinc.MatchInvaders.Unit
{
    public interface IUnitGroupModel : IReadUnitGroupModel, IUnitSubModel { }

    public interface IReadUnitGroupModel : IReadUnitSubModel
    {
        int GroupId { get; }
    }
}