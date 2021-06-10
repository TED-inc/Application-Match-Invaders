namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public class UnitGroupModel : IUnitGroupModel
    {
        public int GroupId { get; private set; }

        public UnitGroupModel(int groupId) =>
            GroupId = groupId;
    }
}