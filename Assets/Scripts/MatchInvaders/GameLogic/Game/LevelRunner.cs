using UnityEngine;

namespace TEDinc.MatchInvaders.GameLogic
{
    public sealed class LevelRunner : MonoBehaviour
    {
        [SerializeField]
        private Transform playerParent;
        [SerializeField]
        private UnitView playerPrefab;

        [SerializeReference, HideInInspector]
        private IUnitController playerController;

        private void Awake()
        {
            playerController = new PlayerController();
            IUnitView playerView = Instantiate(playerPrefab, playerParent); // TODO: cashe instance
            playerView.Setup();
            playerController.Setup(new PlayerModel(), playerView);
        }

        private void Update()
        {
            playerController.Update(Time.deltaTime);
        }
    }
}