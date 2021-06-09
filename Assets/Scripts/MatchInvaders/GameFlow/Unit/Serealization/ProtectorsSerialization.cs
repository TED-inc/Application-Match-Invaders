using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TEDinc.MatchInvaders.GameLogic;

namespace TEDinc.MatchInvaders.GameFlowOld
{
    [Serializable]
    public class ProtectorsSerialization : UnitSerializationBase<UnitView>
    {
        [SerializeField]
        private LayoutGroup layoutGroup; // TODO: unit must control own position, not by UI components
        [SerializeField, Min(0)]
        private int protectorsCount = 4;

        public override void Setup()
        {
            for (int i = 0; i < protectorsCount; i++)
                CreateInstance(new ProtectorController(), new ProtectorModel());

            CoroutineRunner.instance.StartCoroutine(DisableLayoutGroup());

            IEnumerator DisableLayoutGroup()
            {
                yield return new WaitForEndOfFrame();
                layoutGroup.enabled = false;
            }
        }

        public override void Update(float deltaTime) { }
    }
}