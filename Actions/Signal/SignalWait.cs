using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Signal")]
    [Tooltip("Wait for given signal.")]
    public class SignalWait : FsmStateAction {
        [ObjectType(typeof(Signal))]
        [RequiredField]
        public FsmObject signal;

        public FsmEvent waitEndEvent;

        private Signal mSignal;

        public override void OnEnter() {
            mSignal = (Signal)signal.Value;
            mSignal.callback += OnSignal;
        }

        public override void OnExit() {
            if(mSignal)
                mSignal.callback -= OnSignal;
        }

        void OnSignal() {
            Fsm.Event(waitEndEvent);
            Finish();
        }
    }
}