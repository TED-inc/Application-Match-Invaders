using UnityEngine;
using System.Collections.Generic;
using TEDinc.MatchInvaders.Unit;
using TEDinc.MatchInvaders.Unit.Concrete;
using TEDinc.MatchInvaders.UnitFactory;
using TEDinc.MatchInvaders.UnitFactory.Concrete;
using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.GameFlow.Concrete
{
    public sealed class LevelRunner : ILevelRunner, ILevelResultSystem
    {
        public IReadReactiveProperty<LevelState> CurrentLevelState => levelState;
        public IScoreSystem ScoreSystem { get; private set; } = new ScoreSystem();

        private readonly List<IReadUnitController> unitControllers = new List<IReadUnitController>();
        private readonly IReactiveProperty<LevelState> levelState =
            new ReactiveProperty<LevelState>(LevelState.WaitForStart);

        private IUnitFactory[] unitFactories;
        private ILevelParams levelParams;

        public void LevelStart(ILevelParams levelParams)
        {
            if (levelState.Value != LevelState.WaitForStart)
                return;

            IEnemyUnitGridController enemysGridController = new EnemyGridController(levelParams.EnemyParams, this);
            ScoreSystem.Setup(new[] { new EnemyChainDeathScoreChanger(enemysGridController) });
            this.levelParams = levelParams;

            unitFactories = new IUnitFactory[] {
                new PlayerUnitFactory(levelParams.PlayerParams, this),
                new EnemyUnitFactory(enemysGridController, levelParams.EnemyParams),
                new ProtectorUnitFactory(levelParams.ProtectorParams),
            };


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
            ScoreSystem.ResetCurrentScore();
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

        void ILevelResultSystem.CompleteLevel()
        {
            if (levelState.Value == LevelState.Running)
                levelState.Value = LevelState.Complete;
        }

        void ILevelResultSystem.FailLevel()
        {
            if (levelState.Value == LevelState.Running)
                levelState.Value = LevelState.Failed;
        }
    }
}