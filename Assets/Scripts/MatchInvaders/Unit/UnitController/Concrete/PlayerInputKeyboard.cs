using System;
using UnityEngine;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    [Serializable]
    public sealed class PlayerInputKeyboard : IPlayerInput
    {
        [SerializeField]
        private KeyCode keyMoveLeft = KeyCode.A;
        [SerializeField]
        private KeyCode keyMoveRight = KeyCode.D;
        [SerializeField]
        private KeyCode keyShoot = KeyCode.Space;

        public float GetHorizontalInput() =>
                Input.GetKey(keyMoveLeft) ? -1f :
                Input.GetKey(keyMoveRight) ? 1f :
                0f;

        public bool GetShootInput() =>
            Input.GetKey(keyShoot);
    }

    public interface IPlayerInput
    {
        bool GetShootInput();
        float GetHorizontalInput();
    }
}