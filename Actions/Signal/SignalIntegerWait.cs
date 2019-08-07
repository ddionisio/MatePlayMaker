using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Signal")]
    [Tooltip("Wait for given signal.")]
    public class SignalIntegerWait : FsmStateAction {
        [ObjectType(typeof(SignalInteger))]
        [RequiredField]
        public FsmObject signal;

        [UIHint(UIHint.Variable)]
        public FsmInt output;

        public FsmEvent waitEndEvent;

        private SignalInteger mSignal;

        public override void OnEnter() {
            mSignal = (SignalInteger)signal.Value;
            mSignal.callback += OnSignal;
        }

        public override void OnExit() {
            if(mSignal)
                mSignal.callback -= OnSignal;
        }

        void OnSignal(int v) {
            if(!output.IsNone)
                output.Value = v;

            Fsm.Event(waitEndEvent);

            Finish();
        }
    }
}