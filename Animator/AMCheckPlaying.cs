using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Mate Animator")]
    [Tooltip("Check to see if animator timeline is playing.")]
    public class AMCheckPlaying : FsmStateAction {
        [UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        public FsmEvent isTrue;
        public FsmEvent isFalse;

        public FsmBool everyFrame;

        public override void Reset() {
            isTrue = null;
            isFalse = null;
            storeResult = null;
            everyFrame = null;
        }

        public override void OnEnter() {
            DoCheck();
            if(!everyFrame.Value)
                Finish();
        }

        public override void OnUpdate() {
            DoCheck();
        }

        void DoCheck() {
            bool playing = AnimatorTimeline.aData.isPlaying;

            if(!storeResult.IsNone)
                storeResult.Value = playing;

            if(playing)
                Fsm.Event(isTrue);
            else
                Fsm.Event(isFalse);
        }

        public override string ErrorCheck() {
            if(everyFrame.Value &&
                FsmEvent.IsNullOrEmpty(isTrue) &&
                FsmEvent.IsNullOrEmpty(isFalse))
                return "Action sends no events!";
            return "";
        }
    }
}
