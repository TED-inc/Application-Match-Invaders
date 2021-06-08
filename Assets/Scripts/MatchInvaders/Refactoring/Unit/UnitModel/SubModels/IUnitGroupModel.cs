namespace TEDinc.MatchInvaders.Unit
{
    public interface IUnitGroupModel : IReadUnitGroupModel, IUnitSubModel
    {
        void Setup(int groupId);
    }

    public interface IReadUnitGroupModel : IReadUnitSubModel
    {
        int GroupId { get; }
    }
}