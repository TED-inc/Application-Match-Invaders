using System;
using TEDinc.MatchInvaders.GameLogic;

namespace TEDinc.MatchInvaders.GameFlow
{
    public interface IUnitView : IEffectReciverProxy
    {
        event Action<IEffect> OnEffectRecived;
        IPositionModel Position { get; }
        void Setup();
        void Destroy();
        IUnitView Clone();
    }
}