using UnityEngine;
using TEDinc.MatchInvaders.Unit.Concrete;
using TEDinc.MatchInvaders.Effect.Concrete;
using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.GameFlow
{
    public sealed class LevelRunnerProxy : MonoBehaviour, ILevelRunner
    {
        public IReadReactiveProperty<LevelState> CurrentLevelState => levelRunner.CurrentLevelState;
        public IScoreSystem ScoreSystem => levelRunner.ScoreSystem;

        [SerializeField]
        private PlayerUnitParams playerParams;
        [SerializeField]
        private EnemyUnitParams enemysParams;
        [SerializeField]
        private ProtectorUnitParams protectorParams;

        private ILevelRunner levelRunner;

        public void LevelStart() =>
            levelRunner.LevelStart();

        public void LevelEnd() =>
            levelRunner.LevelEnd();

        public void LevelReStart() =>
            levelRunner.LevelReStart();

        public void LevelSwithPause() =>
            levelRunner.LevelSwithPause();

        public void LevelUpdate(float deltaTime) =>
            levelRunner.LevelUpdate(deltaTime);


        private void Awake()
        {
            levelRunner = new LevelRunner(playerParams, enemysParams, protectorParams);
            CurrentLevelState.OnChange += DestoySpawnedUnits;
        }

        private void Start() =>
            LevelStart();

        private void Update() =>
            LevelUpdate(Time.deltaTime);

        private void OnApplicationQuit() =>
            LevelEnd();

        private void DestoySpawnedUnits(LevelState levelState)
        {
            if (levelState == LevelState.WaitForStart)
                foreach (var parent in new[] { playerParams.Parent, enemysParams.Parent, protectorParams.Parent, EffectSourceParams.Instance.transform })
                    for (int i = 0; i < parent.childCount; i++)
                        Destroy(parent.GetChild(i).gameObject);
        }
    }
}