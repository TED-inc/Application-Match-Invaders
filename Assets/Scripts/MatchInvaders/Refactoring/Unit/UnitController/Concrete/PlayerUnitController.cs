using System;
using UnityEngine;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    [Serializable]
    public sealed class PlayerUnitController : IUnitController
    {
        public IReadUnitModel UnitModel => throw new NotImplementedException();

        public IReadUnitView UnitView => throw new NotImplementedException();

        public void Setup(IUnitModel UnitModel, IUnitView unitView)
        {
            throw new NotImplementedException();
        }

        public void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}