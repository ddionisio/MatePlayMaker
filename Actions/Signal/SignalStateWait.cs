using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Signal")]
    [Tooltip("Wait for given signal state.")]
    public class SignalStateWait : FsmStateAction {
        [ObjectType(typeof(SignalState))]
        [RequiredField]
        public FsmObject signal;

        [UIHint(UIHint.Variable)]
        [ObjectType(typeof(SignalState))]
        public FsmObject stateOutput;

        public FsmEvent waitEndEvent;

        private SignalState mSignal;

        public override void OnEnter() {
            mSignal = (SignalState)signal.Value;
            mSignal.callback += OnSignal;
        }

        public override void OnExit() {
            if(mSignal)
                mSignal.callback -= OnSignal;
        }

        void OnSignal(State state) {
            stateOutput.Value = state;

            Fsm.Event(waitEndEvent);

            Finish();
        }
    }
}