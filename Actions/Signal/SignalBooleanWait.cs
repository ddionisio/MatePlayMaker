using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Signal")]
    [Tooltip("Wait for given signal.")]
    public class SignalBooleanWait : FsmStateAction {
        [ObjectType(typeof(SignalBoolean))]
        [RequiredField]
        public FsmObject signal;

        public FsmEvent trueEvent;
        public FsmEvent falseEvent;

        private SignalBoolean mSignal;

        public override void OnEnter() {
            mSignal = (SignalBoolean)signal.Value;
            mSignal.callback += OnSignal;
        }

        public override void OnExit() {
            if(mSignal)
                mSignal.callback -= OnSignal;
        }

        void OnSignal(bool b) {
            Fsm.Event(b ? trueEvent : falseEvent);
            Finish();
        }
    }
}