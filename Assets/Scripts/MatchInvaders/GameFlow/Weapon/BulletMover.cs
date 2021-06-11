using UnityEngine;

namespace TEDinc.MatchInvaders.GameFlowOld
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class BulletMover : MonoBehaviour
    {
        [SerializeField]
        private float speed = 400f;


        private void Update() =>
            transform.position += transform.up * speed * Time.deltaTime;
    }
}