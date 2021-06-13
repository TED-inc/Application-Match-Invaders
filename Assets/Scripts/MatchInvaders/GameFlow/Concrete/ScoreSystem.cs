using System;
using UnityEngine;
using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.GameFlow.Concrete
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
            PlayerPrefs.SetInt(nameof(Concrete.ScoreSystem), highScore.Value); // TODO: change to persistent save
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

        public void Load() =>
            highScore.SetWithoutNotify(PlayerPrefs.GetInt(nameof(ScoreSystem))); // TODO: change to persistent save
    }
}