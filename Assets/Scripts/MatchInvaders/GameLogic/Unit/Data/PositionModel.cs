using System;
using UnityEngine;

namespace TEDinc.MatchInvaders.GameLogic
{
    [Serializable]
    public sealed class PositionModel : IPositionModel
    {
        public Vector3 WorldPosition 
        { 
            get => worldPosition; 
            set => worldPosition = value;
        }

        [SerializeField]
        private Vector3 worldPosition;
    }
}