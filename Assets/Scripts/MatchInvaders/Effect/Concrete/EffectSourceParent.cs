using UnityEngine;

namespace TEDinc.MatchInvaders.Effect.Concrete
{
    public sealed class EffectSourceParent : MonoBehaviour
    {
        public static Transform Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
                Instance = transform;
            else
                Destroy(gameObject);
        }
    }
}