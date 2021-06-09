using UnityEngine;
using TEDinc.Utils.ReactiveProperty;

namespace TEDinc.MatchInvaders.Effect.Concrete
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class UniversalEffectSource : MonoBehaviour
    {
        private IEffect effect;
        private IReadReactiveProperty<Vector2> position;

        public void Setup(IEffect effect, IReadReactiveProperty<Vector2> position)
        {
            this.effect = effect;
            this.position = position;
            position.OnChange += SetPosition;
        }
            

        public void OnCollisionEnter2D(Collision2D collision)
        {
            collision.gameObject.GetComponent<IEffectReciver>()?.ApplyEffect(effect);
            effect.IsFired.Value = true;
            gameObject.SetActive(false);
            position.OnChange -= SetPosition;
            Destroy(gameObject);
        }

        private void SetPosition(Vector2 position) =>
            transform.localPosition = position;
    }
}