﻿using UnityEngine;
using TEDinc.MatchInvaders.Unit.Concrete;
using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.GameFlow
{
    public sealed class LevelRunnerProxy : MonoBehaviour, ILevelRunner
    {
        public IReadReactiveProperty<LevelState> CurrentLevelState => levelRunner.CurrentLevelState;

        [SerializeField]
        private PlayerUnitParams playerParams;
        [SerializeField]
        private EnemyUnitParams enemysParams;

        private ILevelRunner levelRunner;

        public void LevelStart()
        {
            if (levelRunner == null)
                levelRunner = new LevelRunner(playerParams, enemysParams);
            CurrentLevelState.OnChange += DestoySpawnedUnits;
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

        private void DestoySpawnedUnits(LevelState levelState)
        {
            if (levelState == LevelState.WaitForStart)
                foreach (var paramBase in new IUnitFactoryParmsBase[] { playerParams, enemysParams })
                    for (int i = 0; i < paramBase.Parent.childCount; i++)
                        Destroy(paramBase.Parent.GetChild(i).gameObject);
        }
    }
}