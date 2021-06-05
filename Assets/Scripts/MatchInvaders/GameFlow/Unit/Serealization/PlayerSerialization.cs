using System;
using UnityEngine;
using TEDinc.MatchInvaders.GameLogic;

namespace TEDinc.MatchInvaders.GameFlow
{
    [Serializable]
    public class PlayerSerialization : UnitSerializationBase<UnitView>
    {
        [SerializeReference, HideInInspector]
        private IUnitController playerController;

        public override void Setup()
        {
            playerController = new PlayerController();
            CreateInstance(playerController, new PlayerModel());
        }

        public override void Update(float deltaTime) =>
            playerController.Update(deltaTime);
    }
}