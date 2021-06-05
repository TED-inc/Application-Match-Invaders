using System;

namespace TEDinc.MatchInvaders.GameLogic
{
    public interface IUnitView : IEffectReciverProxy
    {
        event Action<IEffect> OnEffectRecived;
        IPositionModel Position { get; }
        void Setup();
        void Destroy();
    }
}