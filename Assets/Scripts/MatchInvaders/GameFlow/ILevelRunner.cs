using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.GameFlow
{
    public interface ILevelRunner
    {
        IScoreSystem ScoreSystem { get; }
        IReadReactiveProperty<LevelState> CurrentLevelState { get; }
        void LevelStart();
        void LevelEnd();
        void LevelReStart();
        void LevelSwithPause();
        void LevelUpdate(float deltaTime);
    }

    public enum LevelState
    {
        WaitForStart,
        Running,
        Paused,
    }
}