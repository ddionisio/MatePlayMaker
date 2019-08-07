using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Signal")]
    [Tooltip("Wait for given signal.")]
    public class SignalStringWait : FsmStateAction {
        [ObjectType(typeof(SignalString))]
        [RequiredField]
        public FsmObject signal;

        [UIHint(UIHint.Variable)]
        public FsmString output;

        public FsmEvent waitEndEvent;

        private SignalString mSignal;

        public override void OnEnter() {
            mSignal = (SignalString)signal.Value;
            mSignal.callback += OnSignal;
        }

        public override void OnExit() {
            if(mSignal)
                mSignal.callback -= OnSignal;
        }

        void OnSignal(string v) {
            if(!output.IsNone)
                output.Value = v;

            Fsm.Event(waitEndEvent);

            Finish();
        }
    }
}