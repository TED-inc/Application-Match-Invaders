using UnityEngine;
using TEDinc.MatchInvaders.Unit.Concrete;
using TEDinc.MatchInvaders.Effect.Concrete;
using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.GameFlow.Concrete
{
    public sealed class LevelRunnerProxy : MonoBehaviour, ILevelRunner
    {
        public IReadReactiveProperty<LevelState> CurrentLevelState => levelRunner.CurrentLevelState;
        public IScoreSystem ScoreSystem => levelRunner.ScoreSystem;

        [SerializeField]
        private LevelParamsSO levelParams;
        [SerializeField]
        private Transform playerParent;
        [SerializeField]
        private Transform enemysParent;
        [SerializeField]
        private Transform protectorParent;

        private ILevelRunner levelRunner = new LevelRunner();

        public void LevelStart() =>
            LevelStart(levelParams);

        public void LevelStart(ILevelParams levelParams)
        {
            levelParams.SetParentsToParams(playerParent, enemysParent, protectorParent);
            levelRunner.LevelStart(levelParams);
        }

        public void LevelEnd() =>
            levelRunner.LevelEnd();

        public void LevelReStart()
        {
            LevelEnd();
            LevelStart(levelParams);
        }

        public void LevelSwithPause() =>
            levelRunner.LevelSwithPause();

        public void LevelUpdate(float deltaTime) =>
            levelRunner.LevelUpdate(deltaTime);


        private void Awake()
        {
            CurrentLevelState.OnChange += DestoySpawnedUnits;
            ScoreSystem.Load();
        }

        private void Update() =>
            LevelUpdate(Time.deltaTime);

        private void OnApplicationQuit() =>
            LevelEnd();

        private void DestoySpawnedUnits(LevelState levelState)
        {
            if (levelState == LevelState.WaitForStart)
                foreach (var parent in new[] { playerParent, enemysParent, protectorParent, EffectSourceParams.Instance.transform })
                    for (int i = 0; i < parent.childCount; i++)
                        Destroy(parent.GetChild(i).gameObject);
        }
    }
}