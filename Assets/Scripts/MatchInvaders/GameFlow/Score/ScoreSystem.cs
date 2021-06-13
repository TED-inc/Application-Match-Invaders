using System;
using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.GameFlow
{
    public sealed class ScoreSystem : IScoreSystem
    {
        public IReadReactiveProperty<int> HighScore => highScore;
        public IReadReactiveProperty<int> CurrentScore => currentScore;

        private readonly IReactiveProperty<int> highScore = new ReactiveProperty<int>(0);
        private readonly IReactiveProperty<int> currentScore = new ReactiveProperty<int>(0);
        private IScoreChanger[] scoreChangers;

        private void AddScore(int v)
        {
            currentScore.Value += v;
            highScore.Value = Math.Max(highScore.Value, currentScore.Value);
        }

        public void ResetCurrentScore()
        {
            foreach (IScoreChanger scoreChanger in scoreChangers)
                scoreChanger.OnResetCurrentScore();
            currentScore.Value = 0;
        }

        public void Setup(IScoreChanger[] scoreChangers)
        {
            this.scoreChangers = scoreChangers;
            foreach (IScoreChanger scoreChanger in scoreChangers)
                scoreChanger.OnScoreChanged += AddScore;
        }

        public ScoreSystem(int highScore) =>
            this.highScore.SetWithoutNotify(highScore);
    }
}