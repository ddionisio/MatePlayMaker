using UnityEngine;
using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Signal")]
    [Tooltip("Wait for given signal.")]
    public class SignalVector3Wait : FsmStateAction {
        [ObjectType(typeof(SignalVector3))]
        [RequiredField]
        public FsmObject signal;

        [UIHint(UIHint.Variable)]
        public FsmVector3 output;

        public FsmEvent waitEndEvent;

        private SignalVector3 mSignal;

        public override void OnEnter() {
            mSignal = (SignalVector3)signal.Value;
            mSignal.callback += OnSignal;
        }

        public override void OnExit() {
            if(mSignal)
                mSignal.callback -= OnSignal;
        }

        void OnSignal(Vector3 v) {
            if(!output.IsNone)
                output.Value = v;

            Fsm.Event(waitEndEvent);

            Finish();
        }
    }
}