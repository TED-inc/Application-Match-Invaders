using System;
using UnityEngine;

namespace TEDinc.MatchInvaders.GameLogic
{
    [Serializable]
    public sealed class TransformPositionModel : IPositionModel
    {
        public Vector3 WorldPosition 
        { 
            get => transform.position;
            set => transform.position = value;
        }

        [SerializeField]
        private Transform transform;

        public TransformPositionModel(Transform transform) =>
            this.transform = transform;
    }
}