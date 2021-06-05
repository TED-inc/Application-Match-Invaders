using UnityEngine;

namespace TEDinc.MatchInvaders.GameFlow
{
    public sealed class LevelRunner : MonoBehaviour
    {
        [SerializeField]
        private PlayerSerialization playerSerialization;
        [SerializeField]
        private ProtectorsSerialization protectorsSerialization;
        [SerializeField]
        private EnemysGridSerialization enemysGridSerialization;

        private IUnitSerialization[] unitSerealizations;

        private void Start()
        {
            unitSerealizations = new IUnitSerialization[] {
                playerSerialization,
                protectorsSerialization,
                enemysGridSerialization,
            };

            foreach (IUnitSerialization unitSerealization in unitSerealizations)
                unitSerealization.Setup();
        }

        private void Update()
        {
            foreach (IUnitSerialization unitSerealization in unitSerealizations)
                unitSerealization.Update(Time.deltaTime);
        }
    }
}