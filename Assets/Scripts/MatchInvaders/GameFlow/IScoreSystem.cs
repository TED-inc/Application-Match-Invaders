using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.GameFlow
{    public interface IScoreSystem
    {
        IReadReactiveProperty<int> HighScore { get; }
        IReadReactiveProperty<int> CurrentScore { get; }

        void Load();
        void Setup(IScoreChanger[] scoreChangers);
        void ResetCurrentScore();
    }
}