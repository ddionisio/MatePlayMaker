using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Animator")]
    [Tooltip("Get the current take that is playing.")]
    public class AMGetCurrentTake : FsmStateAction {
        [UIHint(UIHint.Variable)]
        [RequiredField]
        public FsmString output;

        public override void Reset() {
            output = null;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            output.Value = AnimatorTimeline.aData.takeName;
            Finish();
        }
    }
}
