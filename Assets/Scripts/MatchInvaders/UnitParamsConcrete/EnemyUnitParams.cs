using System;
using UnityEngine;
using UnityEngine.UI;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    [Serializable]
    public class EnemyUnitParams : UnitParmsBase, IEnemyUnitParams
    {
        public int MaxBulletCount => maxBulletCount;
        public float ShootAttemtProbability => shootPerSecProbability;
        public int GridSizeX => gridSize.x;
        public int GridSizeY => gridSize.y;
        public int GroupCount => groupCount;
        public int MaxChindedKill => maxChainedKill;
        public Vector2 CellSize => cellSize;

        [SerializeField]
        private AnimationCurve positionByTime = new AnimationCurve(
            new Keyframe(0f, 0f),
            new Keyframe(0.5f, 50f),
            new Keyframe(1f, 50f),
            new Keyframe(2f, -50f),
            new Keyframe(2.5f, -50f),
            new Keyframe(3f, 0f),
            new Keyframe(4f, 0f));

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
        private Vector2 cellSize = new Vector2(100f, 100f);
        [SerializeField]
        private AnimationCurve aliveCountToSpeed = new AnimationCurve(new Keyframe(0f, 3f), new Keyframe(1f, 1f));
        [SerializeField]
        private AnimationCurve lineIndexToMoveDelay = new AnimationCurve(new Keyframe(0f, 3f), new Keyframe(6f, 10f));


        public float SpeedByAlivePercent(float p) =>
            aliveCountToSpeed.Evaluate(p);

        public float MoveStartDelayByLine(int lineNumber) =>
            lineIndexToMoveDelay.Evaluate(lineNumber);

        public float GetPosOverTime(float f) =>
            positionByTime.Evaluate(f % positionByTime.keys[positionByTime.length - 1].time);
    }

    public interface IEnemyUnitParams : IUnitFactoryParmsBase, IGridParams, IEnemyGrid
    {
        int MaxBulletCount { get; }
        float ShootAttemtProbability { get; }
        float SpeedByAlivePercent(float p);
        float MoveStartDelayByLine(int lineNumber);
        float GetPosOverTime(float f);
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
        Vector2 CellSize { get; }
    }
}