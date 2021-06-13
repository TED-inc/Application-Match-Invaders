using UnityEngine;
using UnityEngine.Events;
using TEDinc.MatchInvaders.GameFlow;
using TEDinc.MatchInvaders.GameFlow.Concrete;

namespace TEDinc.MatchInvaders.UI
{
    public sealed class MenusManger : MonoBehaviour
    {
        [SerializeField]
        private LevelRunnerProxy levelRunner;
        [SerializeField]
        private KeyCode keySwitchToPause = KeyCode.Escape;

        [SerializeField]
        private UnityEventBool onSwitchToStartWindow;
        [SerializeField]
        private UnityEventBool onSwitchToPauseWindow;
        [SerializeField]
        private UnityEventBool onSwitchToCompleteWindow;
        [SerializeField]
        private UnityEventBool onSwitchToFailedWindow;


        public void ExitGame() =>
            Application.Quit();

        private void Start()
        {
            OnSwitchLevelState(levelRunner.CurrentLevelState.Value);
            levelRunner.CurrentLevelState.OnChange += OnSwitchLevelState;
        }

        private void OnDestroy() =>
            levelRunner.CurrentLevelState.OnChange -= OnSwitchLevelState;

        private void Update()
        {
            if (Input.GetKeyDown(keySwitchToPause))
                levelRunner.LevelSwithPause();
        }

        private void OnSwitchLevelState(LevelState levelState)
        {
            onSwitchToStartWindow.Invoke(levelState == LevelState.WaitForStart);
            onSwitchToPauseWindow.Invoke(levelState == LevelState.Paused);
            onSwitchToCompleteWindow.Invoke(levelState == LevelState.Complete);
            onSwitchToFailedWindow.Invoke(levelState == LevelState.Failed);
        }
    }
}