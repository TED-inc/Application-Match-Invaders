using UnityEngine;
using TEDinc.MatchInvaders.GameFlow;
using TEDinc.MatchInvaders.GameFlow.Concrete;

namespace TEDinc.MatchInvaders.Effect.Concrete
{
    public sealed class EffectSourceParams : MonoBehaviour
    {
        public static EffectSourceParams Instance { get; private set; }

        public float GameSpeed => levelRunner.CurrentLevelState.Value == LevelState.Running ? 1f : 0f;

        [SerializeField]
        private LevelRunnerProxy levelRunner;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }
    }
}