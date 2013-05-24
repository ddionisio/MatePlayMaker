using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Mate Pool")]
    [Tooltip("Release given game object")]
    public class PoolRelease : FsmStateAction {
        [RequiredField]
        public FsmString group;

        [RequiredField]
        public FsmGameObject gameObject;

        public override void Reset() {
            base.Reset();

            group = null;
            gameObject = null;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
#if POOLMANAGER
            Debug.LogError("Not implemented!");
#else
            PoolController.Release(group.Value, gameObject.Value.transform);
#endif
            Finish();
        }


    }
}