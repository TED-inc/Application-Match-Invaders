using UnityEngine;
using TEDinc.MatchInvaders.GameLogic;

namespace TEDinc.MatchInvaders.GameFlow
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class PhysicsEffect : MonoBehaviour
    {
        private IEffect effect;

        public void SetEffect(IEffect effect) =>
            this.effect = effect;

        public void OnCollisionEnter2D(Collision2D collision)
        {
            collision.gameObject.GetComponent<IEffectReciver>()?.ApplyEffect(effect);
            effect.IsFired = true;
            Destroy(gameObject);
        }
    }
}