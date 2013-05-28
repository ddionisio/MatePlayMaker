using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Animator")]
    [Tooltip("Play a take from the animator timeline.")]
    public class AMPlayTake : FsmStateAction {
        [RequiredField]
        public FsmString take;

        public FsmBool loop;

        public override void Reset() {
            take = null;
            loop = null;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            AnimatorTimeline.aData.Play(take.Value, loop.Value);
            Finish();
        }
    }
}
