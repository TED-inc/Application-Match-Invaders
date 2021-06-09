﻿using System;
using UnityEngine;
using UnityEngine.UI;
using TEDinc.MatchInvaders.GameLogic;

namespace TEDinc.MatchInvaders.GameFlowOld
{
    [Serializable]
    public sealed class EnemyView : UnitView, IEnemyGroupElement
    {
        public bool CanShoot;

        [SerializeField]
        private Image image;

        public void SetGroup(int i)
        {
            image.color = GetColor(i);

            Color GetColor(int index)
            {
                switch (index)
                {
                    case 0:
                        return Color.red;
                    case 1:
                        return Color.green;
                    case 2:
                        return Color.yellow;
                    case 3:
                        return Color.blue;
                    default:
                        throw new NotImplementedException();
                }
            }

        }
    }
}