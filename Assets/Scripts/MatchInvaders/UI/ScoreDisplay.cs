using UnityEngine;
using UnityEngine.Events;
using TEDinc.MatchInvaders.GameFlow.Concrete;

namespace TEDinc.MatchInvaders.UI
{
    public sealed class ScoreDisplay : MonoBehaviour
    {
        [SerializeField]
        private LevelRunnerProxy levelRunner;
        [SerializeField]
        private UnityEventInt onScoreChanged;
        [SerializeField]
        private UnityEventInt onHighChanged;

        private void Start()
        {
            onScoreChanged.Invoke(levelRunner.ScoreSystem.CurrentScore.Value);
            onHighChanged.Invoke(levelRunner.ScoreSystem.HighScore.Value);

            levelRunner.ScoreSystem.CurrentScore.OnChange += onScoreChanged.Invoke;
            levelRunner.ScoreSystem.HighScore.OnChange += onHighChanged.Invoke;
        }

        private void OnDestroy()
        {
            levelRunner.ScoreSystem.CurrentScore.OnChange -= onScoreChanged.Invoke;
            levelRunner.ScoreSystem.HighScore.OnChange -= onHighChanged.Invoke;
        }
    }
}