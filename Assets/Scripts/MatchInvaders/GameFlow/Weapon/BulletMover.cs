using UnityEngine;

namespace TEDinc.MatchInvaders.GameFlowOld
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class BulletMover : MonoBehaviour
    {
        [SerializeField]
        private Vector2 speed = Vector2.up * 400;


        private void Update() =>
            transform.position += (Vector3)speed * Time.deltaTime;
    }
}