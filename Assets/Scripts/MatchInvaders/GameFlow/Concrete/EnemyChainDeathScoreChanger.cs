using System;
using TEDinc.MatchInvaders.Unit.Concrete;

namespace TEDinc.MatchInvaders.GameFlow.Concrete
{
    public sealed class EnemyChainDeathScoreChanger : IScoreChanger
    {
        public event Action<int> OnScoreChanged = ActionExt.GetNullObject<int>();
        private readonly IUnitsGridController enemysGridController;

        private int currentCount = -1;

        private void OnAliveUnitsCountChanged(int newCount)
        {
            if (currentCount < 0)
                currentCount = enemysGridController.TotalUnitsCount;
            int destoyedEnemysCount = currentCount - newCount;
            int scoreCount = destoyedEnemysCount * Fibonachi(destoyedEnemysCount + 1) * 10;

            OnScoreChanged.Invoke(scoreCount);
            currentCount = newCount;



            int Fibonachi(int index)
            {
                int a = 0;
                int b = 1;

                for (int i = 0; i < index; i++)
                {
                    int _b = b;
                    b += a;
                    a = _b;
                }

                return a;
            }
        }

        public void OnResetCurrentScore() =>
            currentCount = -1;

        public EnemyChainDeathScoreChanger(IUnitsGridController unitsGridController)
        {
            this.enemysGridController = unitsGridController;
            unitsGridController.AliveUnitsCount.OnChange += OnAliveUnitsCountChanged;
        }
    }
}