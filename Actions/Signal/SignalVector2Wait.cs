using UnityEngine;
using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Signal")]
    [Tooltip("Wait for given signal.")]
    public class SignalVector2Wait : FsmStateAction {
        [ObjectType(typeof(SignalVector2))]
        [RequiredField]
        public FsmObject signal;

        [UIHint(UIHint.Variable)]
        public FsmVector2 output;

        public FsmEvent waitEndEvent;

        private SignalVector2 mSignal;

        public override void OnEnter() {
            mSignal = (SignalVector2)signal.Value;
            mSignal.callback += OnSignal;
        }

        public override void OnExit() {
            if(mSignal)
                mSignal.callback -= OnSignal;
        }

        void OnSignal(Vector2 v) {
            if(!output.IsNone)
                output.Value = v;

            Fsm.Event(waitEndEvent);

            Finish();
        }
    }
}