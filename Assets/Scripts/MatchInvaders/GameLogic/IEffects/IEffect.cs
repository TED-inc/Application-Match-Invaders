using UnityEngine;

namespace TEDinc.MatchInvaders.GameLogic
{
    // TODO : separate to Read and Write, make IsFired reactive
    public interface IEffect
    { 
        bool IsFired { get; set; }
        IEffect Clone();
        void SetPhysics(Vector3 position);
    }
}