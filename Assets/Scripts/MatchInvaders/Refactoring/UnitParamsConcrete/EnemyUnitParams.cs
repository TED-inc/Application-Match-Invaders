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
        public float ShootAttemtProbability => shootAttemtProbability;
        public int GridSizeX => gridSize.x;
        public int GridSizeY => gridSize.y;
        public int GroupCount => groupCount;
        public Behaviour GridLayout => layoutGroup;
        public int MaxChindedKill => maxChainedKill;

        [SerializeField, Min(0f)]
        private float positionLimitXAbs = 50;
        [SerializeField, Min(0)]
        private int maxBulletCount = 5;
        [SerializeField, Min(0)]
        private int maxChainedKill = 4;
        [SerializeField, Range(0f, 1f)]
        private float shootAttemtProbability = 0.05f;
        

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
    }

    public interface IEnemyUnitParams : IUnitFactoryParmsBase, IGridParams
    {
        float PositionLimitXAbs { get; }
        int MaxBulletCount { get; }
        float ShootAttemtProbability { get; }
        float SpeedByCount(int aliveCount);
        float MoveStartDelayByLine(int lineNumber);
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