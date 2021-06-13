using System;

namespace TEDinc.MatchInvaders.GameFlow
{
    public interface IScoreChanger
    {
        event Action<int> OnScoreChanged;
        void OnResetCurrentScore();
    }
}