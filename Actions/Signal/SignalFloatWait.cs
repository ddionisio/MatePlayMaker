using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Signal")]
    [Tooltip("Wait for given signal.")]
    public class SignalFloatWait : FsmStateAction {
        [ObjectType(typeof(SignalFloat))]
        [RequiredField]
        public FsmObject signal;

        [UIHint(UIHint.Variable)]
        public FsmFloat output;

        public FsmEvent waitEndEvent;

        private SignalFloat mSignal;

        public override void OnEnter() {
            mSignal = (SignalFloat)signal.Value;
            mSignal.callback += OnSignal;
        }

        public override void OnExit() {
            if(mSignal)
                mSignal.callback -= OnSignal;
        }

        void OnSignal(float v) {
            if(!output.IsNone)
                output.Value = v;

            Fsm.Event(waitEndEvent);

            Finish();
        }
    }
}