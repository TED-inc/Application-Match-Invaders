using System;
using UnityEngine;
using UnityEngine.UI;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    [Serializable]
    public class EnemyUnitParams : UnitParmsBase, IEnemyUnitParams
    {
        public float PositionLimitXAbs => positionLimitXAbs;
        public int MaxBulletCount => maxBulletCount;
        public float ShootAttemtProbability => shootPerSecProbability;
        public int GridSizeX => gridSize.x;
        public int GridSizeY => gridSize.y;
        public int GroupCount => groupCount;
        public Behaviour GridLayout => layoutGroup;
        public int MaxChindedKill => maxChainedKill;

        [SerializeField, Min(0f)]
        private float positionLimitXAbs = 50;
        [SerializeField]
        private AnimationCurve positionByTime = new AnimationCurve(
            new Keyframe(0f, 0f),
            new Keyframe(0.25f, 1f),
            new Keyframe(0.5f, 0f),
            new Keyframe(0.75f, -1f),
            new Keyframe(1f, 0f));

        [Header("Shooting")]
        [SerializeField, Min(0f)]
        private int maxBulletCount = 5;
        [SerializeField, Min(0f)]
        private int maxChainedKill = 4;
        [SerializeField, Min(0f)]
        private float shootPerSecProbability = 0.05f;

        [Header("Grid")]
        [SerializeField, Range(1, GameConst.MaxEnenmyGroupsCount)]
        private int groupCount = GameConst.MaxEnenmyGroupsCount;
        [SerializeField]
        private Vector2Int gridSize = new Vector2Int(17, 6);
        [SerializeField]
        private AnimationCurve aliveCountToSpeed = new AnimationCurve(new Keyframe(0f, 100f), new Keyframe(100f, 30f));
        [SerializeField]
        private AnimationCurve lineIndexToMoveDelay = new AnimationCurve(new Keyframe(0f, 3f), new Keyframe(6f, 10f));
        [SerializeField]
        private LayoutGroup layoutGroup;


        public float SpeedByCount(int aliveCount) =>
            aliveCountToSpeed.Evaluate(aliveCount);

        public float MoveStartDelayByLine(int lineNumber) =>
            lineIndexToMoveDelay.Evaluate(lineNumber);

        public float XPosByTimeStep(float f) =>
            positionByTime.Evaluate(f);
    }

    public interface IEnemyUnitParams : IUnitFactoryParmsBase, IGridParams, IEnemyGrid
    {
        float PositionLimitXAbs { get; }
        int MaxBulletCount { get; }
        float ShootAttemtProbability { get; }
        float SpeedByCount(int aliveCount);
        float MoveStartDelayByLine(int lineNumber);
        float XPosByTimeStep(float f);
    }

    public interface IEnemyGrid
    {
        int GroupCount { get; }
        int MaxChindedKill { get; }
    }

    public interface IGridParams
    {
        int GridSizeX { get; }
        int GridSizeY { get; }
        Behaviour GridLayout { get; }
    }
}