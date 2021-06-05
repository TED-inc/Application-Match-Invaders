using System;
using UnityEngine;
using TEDinc.MatchInvaders.GameLogic;

namespace TEDinc.MatchInvaders.GameFlow
{
    [Serializable]
    public class ProtectorsSerialization : UnitSerializationBase<UnitView>
    {
        [SerializeField, Min(0)]
        private int protectorsCount = 4;

        public override void Setup()
        {
            for (int i = 0; i < protectorsCount; i++)
                CreateInstance(new ProtectorController(), new ProtectorModel());
        }

        public override void Update(float deltaTime) { }
    }
}