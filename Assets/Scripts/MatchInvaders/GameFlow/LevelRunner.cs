using UnityEngine;
using System.Collections.Generic;
using TEDinc.MatchInvaders.Unit;
using TEDinc.MatchInvaders.Unit.Concrete;
using TEDinc.MatchInvaders.UnitFactory;
using TEDinc.MatchInvaders.UnitFactory.Concrete;
using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.GameFlow
{
    public sealed class LevelRunner : ILevelRunner
    {
        public IReadReactiveProperty<LevelState> CurrentLevelState => levelState;
        public IScoreSystem ScoreSystem { get; private set; }

        private readonly IUnitFactory[] unitFactories;
        private readonly List<IReadUnitController> unitControllers = new List<IReadUnitController>();
        private readonly IReactiveProperty<LevelState> levelState =
            new ReactiveProperty<LevelState>(LevelState.WaitForStart);

        public void LevelStart()
        {
            if (levelState.Value != LevelState.WaitForStart)
                return;

            foreach (IUnitFactory unitFactory in unitFactories)
            {
                unitFactory.Reset();
                while (!unitFactory.IsComplete())
                    unitControllers.Add(unitFactory.Next());
            }
            levelState.Value = LevelState.Running;
        }

        public void LevelEnd()
        {
            unitControllers.Clear();
            levelState.Value = LevelState.WaitForStart;
            SaveScoreSystem();
        }

        public void LevelReStart()
        {
            LevelEnd();
            LevelStart();
        }

        public void LevelUpdate(float deltaTime)
        {
            if (levelState.Value == LevelState.Running)
                unitControllers.ForEach(u => u.Update(deltaTime));
        }

        public void LevelSwithPause()
        {
            if (levelState.Value == LevelState.Running)
                levelState.Value = LevelState.Paused;
            else if (levelState.Value == LevelState.Paused)
                levelState.Value = LevelState.Running;
        }

        public LevelRunner(IPlayerUnitParams playerParams, IEnemyUnitParams enemyParams, IProtectorUnitParams protectorParams)
        {
            IUnitsGridController enemysGridController = new EnemyGridController(enemyParams);
            ScoreSystem = new ScoreSystem(PlayerPrefs.GetInt(nameof(GameFlow.ScoreSystem))); // TODO: change to persistent save
            ScoreSystem.Setup(new[] { new EnemyChainDeathScoreChanger(enemysGridController) });
           
            unitFactories = new IUnitFactory[] { 
                new PlayerUnitFactory(playerParams),
                new EnemyUnitFactory(enemysGridController, enemyParams),
                new ProtectorUnitFactory(protectorParams),
            };
        }

        private void SaveScoreSystem() =>
            PlayerPrefs.SetInt(nameof(GameFlow.ScoreSystem), ScoreSystem.HighScore.Value); // TODO: change to persistent save
    }
}