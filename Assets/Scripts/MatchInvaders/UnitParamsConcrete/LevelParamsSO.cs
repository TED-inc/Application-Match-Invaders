using UnityEngine;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    [CreateAssetMenu]
    public sealed class LevelParamsSO : ScriptableObject, ILevelParams
    {
        public IPlayerUnitParams PlayerParams => playerParams;
        public IEnemyUnitParams EnemyParams => enemysParams;
        public IProtectorUnitParams ProtectorParams => protectorParams;

        [SerializeField]
        private PlayerUnitParams playerParams;
        [SerializeField]
        private EnemyUnitParams enemysParams;
        [SerializeField]
        private ProtectorUnitParams protectorParams;

        public void SetParentsToParams(Transform playerParent, Transform enemysParent, Transform protectorsParent)
        {
            playerParams.SetParent(playerParent);
            enemysParams.SetParent(enemysParent);
            protectorParams.SetParent(protectorsParent);
        }
    }

    public interface ILevelParams
    {
        IPlayerUnitParams PlayerParams { get; }
        IEnemyUnitParams EnemyParams { get; }
        IProtectorUnitParams ProtectorParams { get; }
        void SetParentsToParams(Transform playerParent, Transform enemysParent, Transform protectorsParent);
    }
}