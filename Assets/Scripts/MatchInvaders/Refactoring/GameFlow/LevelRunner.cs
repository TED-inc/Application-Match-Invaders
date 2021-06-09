using System;
using System.Collections.Generic;
using TEDinc.MatchInvaders.Unit;
using TEDinc.MatchInvaders.Unit.Concrete;
using TEDinc.MatchInvaders.UnitFactory;
using TEDinc.MatchInvaders.UnitFactory.Concrete;

namespace TEDinc.MatchInvaders.GameFlow
{
    public sealed class LevelRunner : ILevelRunner
    {
        public LevelState LevelState { get; private set; } = LevelState.WaitForStart;

        private readonly IPlayerUnitParams playerParms;
        private readonly IUnitFactory playerFactory;
        private readonly List<IReadUnitController> unitControllers = new List<IReadUnitController>();

        public void LevelStart()
        {
            if (LevelState != LevelState.WaitForStart)
                return;

            unitControllers.Add(playerFactory.Next());
            LevelState = LevelState.Running;
        }

        public void LevelEnd()
        {
            unitControllers.Clear();
            LevelState = LevelState.WaitForStart;
        }

        public void LevelReStart()
        {
            LevelEnd();
            LevelStart();
        }

        public void LevelUpdate(float deltaTime)
        {
            if (LevelState == LevelState.Running)
                unitControllers.ForEach(u => u.Update(deltaTime));
        }

        public void LevelSwithPause()
        {
            if (LevelState == LevelState.Running)
                LevelState = LevelState.Paused;
            else if (LevelState == LevelState.Paused)
                LevelState = LevelState.Running;
        }

        public LevelRunner(IPlayerUnitParams playerParms)
        {
            this.playerParms = playerParms;

            playerFactory = new PlayerUnitFactory(playerParms);
        }
    }
}