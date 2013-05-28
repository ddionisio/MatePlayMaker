using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Animator")]
    [Tooltip("Resume animator timeline.")]
    public class AMResume : FsmStateAction {

        // Code that runs on entering the state.
        public override void OnEnter() {
            AnimatorTimeline.aData.Resume();
            Finish();
        }
    }
}
