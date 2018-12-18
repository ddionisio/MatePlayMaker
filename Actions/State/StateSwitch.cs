using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate State")]
    [Tooltip("Switch states.")]
    public class StateSwitch : FsmStateAction {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        [ObjectType(typeof(State))]
        public FsmObject state;

        [CompoundArray("State Switches", "Compare Int", "Send Event")]
        [ObjectType(typeof(State))]
        public FsmObject[] compareTo;
        public FsmEvent[] sendEvent;

        public FsmBool everyFrame;

        public override void Reset() {
            state = null;
            compareTo = new FsmObject[1];
            sendEvent = new FsmEvent[1];
            everyFrame = false;
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
            if(state.IsNone)
                return;

            for(int i = 0; i < compareTo.Length; i++) {
                if(state.Value == compareTo[i].Value) {
                    Fsm.Event(sendEvent[i]);
                    return;
                }
            }
        }
    }
}