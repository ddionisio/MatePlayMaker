using UnityEngine;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Pool")]
    [Tooltip("Release object if it's spawned. Will just deactivate otherwise.")]
    public class PoolObjectRelease : ComponentAction<PoolDataController> {
        [RequiredField]
        public FsmOwnerDefault gameObject;

        public override void OnEnter() {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(UpdateCache(go))
                cachedComponent.Release();
            else if(go)
                go.SetActive(false);

            Finish();
        }
    }
}