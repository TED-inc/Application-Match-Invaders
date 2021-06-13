using TEDinc.MatchInvaders.Unit.Concrete;
using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.GameFlow
{
    public interface ILevelRunner
    {
        IScoreSystem ScoreSystem { get; }
        IReadReactiveProperty<LevelState> CurrentLevelState { get; }
        void LevelStart(ILevelParams levelParams);
        void LevelEnd();
        void LevelSwithPause();
        void LevelUpdate(float deltaTime);
    }

    public enum LevelState
    {
        WaitForStart,
        Running,
        Paused,
        Complete,
        Failed,
    }
}