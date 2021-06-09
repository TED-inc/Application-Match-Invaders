namespace TEDinc.MatchInvaders.GameFlow
{
    public interface ILevelRunner
    {
        LevelState LevelState { get; }
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