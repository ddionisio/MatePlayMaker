using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Animator")]
    [Tooltip("Pause animator timeline.")]
    public class AMStop : FsmStateAction {

        // Code that runs on entering the state.
        public override void OnEnter() {
            AnimatorTimeline.aData.Stop();
            Finish();
        }
    }
}
