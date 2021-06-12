using UnityEngine;
using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.Effect.Concrete
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class UniversalEffectSource : MonoBehaviour, IEffectSource
    {
        private IEffect effect;

        public void Setup(IEffect effect)
        {
            this.effect = effect;
        }
            

        public void OnCollisionEnter2D(Collision2D collision)
        {
            collision.gameObject.GetComponent<IEffectReciver>()?.ApplyEffect(effect);
            effect.IsFired.Value = true;
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    public interface IEffectSource
    {
        void Setup(IEffect effect);
    }
}