using UnityEngine;
using TEDinc.MatchInvaders.Unit.Concrete;

namespace TEDinc.MatchInvaders.GameFlow
{
    public sealed class LevelRunnerProxy : MonoBehaviour, ILevelRunner
    {
        public LevelState LevelState => levelRunner.LevelState;

        [SerializeField]
        private PlayerUnitParams playerParams;

        private ILevelRunner levelRunner;

        public void LevelStart()
        {
            if (levelRunner == null)
                levelRunner = new LevelRunner(playerParams);
            levelRunner.LevelStart();
        }

        public void LevelEnd() =>
            levelRunner.LevelEnd();

        public void LevelReStart() =>
            levelRunner.LevelReStart();

        public void LevelSwithPause() =>
            levelRunner.LevelSwithPause();

        public void LevelUpdate(float deltaTime) =>
            levelRunner.LevelUpdate(deltaTime);

        private void Start() =>
            LevelStart();

        private void Update() =>
            LevelUpdate(Time.deltaTime);
    }
}