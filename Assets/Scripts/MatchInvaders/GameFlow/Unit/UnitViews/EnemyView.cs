using System;
using UnityEngine;
using UnityEngine.UI;

namespace TEDinc.MatchInvaders.GameFlow
{
    [Serializable]
    public sealed class EnemyView : UnitView
    {
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