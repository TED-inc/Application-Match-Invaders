using UnityEngine;
using TEDinc.MatchInvaders.GameLogic;

namespace TEDinc.MatchInvaders.GameFlow
{
    public class EnemyWeapon : WeaponBase
    {
        [SerializeField]
        private int maxBulletCount = 5;
        [SerializeField, Range(0f, 1f)]
        private float shootProbability = 0.2f;
        [SerializeField]
        private EnemyView enemy;

        private IEffect effect;

        private static IEffect[] effects;

        private void Awake() =>
            effects = new IEffect[maxBulletCount];

        private void Update()
        {
            if (enemy.CanShoot && (effect == null || effect.IsFired) && Random.Range(0f, 1f) <= shootProbability * Time.deltaTime)
                ShootIfPossible();

            void ShootIfPossible()
            {
                for (int i = 0; i < effects.Length; i++)
                    if (effects[i] == null || effects[i].IsFired)
                    {
                        effect = effects[i] = Shoot();
                        return;
                    }
            }
        }
    }
}