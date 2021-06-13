using UnityEngine;
using UnityEngine.Events;
using TEDinc.MatchInvaders.GameFlow;

namespace TEDinc.MatchInvaders.UI
{
    public sealed class PauseMenu : MonoBehaviour
    {
        [SerializeField]
        private LevelRunnerProxy levelRunner;
        [SerializeField]
        private KeyCode keySwitchPause = KeyCode.Escape;

        [SerializeField]
        private UnityEventBool onSwitchPause;
        [SerializeField]
        private UnityEventInt onScoreChanged;
        [SerializeField]
        private UnityEventInt onHighChanged;


        private void Start()
        {
            onScoreChanged.Invoke(levelRunner.ScoreSystem.CurrentScore.Value);
            onHighChanged.Invoke(levelRunner.ScoreSystem.HighScore.Value);
            levelRunner.CurrentLevelState.OnChange += OnSwitchedToPasue;
            levelRunner.ScoreSystem.CurrentScore.OnChange += onScoreChanged.Invoke;
            levelRunner.ScoreSystem.HighScore.OnChange += onHighChanged.Invoke;
        }

        private void OnDestroy()
        {
            levelRunner.CurrentLevelState.OnChange -= OnSwitchedToPasue;
            levelRunner.ScoreSystem.CurrentScore.OnChange -= onScoreChanged.Invoke;
            levelRunner.ScoreSystem.HighScore.OnChange -= onHighChanged.Invoke;
        }

        private void Update()
        {
            if (Input.GetKeyDown(keySwitchPause))
                levelRunner.LevelSwithPause();
        }

        private void OnSwitchedToPasue(LevelState levelState) =>
            onSwitchPause.Invoke(levelState == LevelState.Paused);
    }
}