using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate State")]
    [Tooltip("Compare two states.")]
    public class StateCompare : FsmStateAction {        
        [Tooltip("Left-hand side state.")]
        [ObjectType(typeof(State))]
        public FsmObject state1;

        [Tooltip("Right-hand side state.")]
        [ObjectType(typeof(State))]
        public FsmObject state2;

        [UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        public FsmEvent isEqual;
        public FsmEvent isNotEqual;

        public FsmBool everyFrame;

        public override void Reset() {
            state1 = null;
            state2 = null;
            storeResult = null;
            isEqual = null;
            isNotEqual = null;
            everyFrame = false;
        }

        public override void OnEnter() {
            DoCompare();

            if(!everyFrame.Value)
                Finish();
        }

        public override void OnUpdate() {
            DoCompare();
        }

        void DoCompare() {            
            bool _isEqual = state1.Value == state2.Value;

            if(!storeResult.IsNone)
                storeResult.Value = _isEqual;

            Fsm.Event(_isEqual ? isEqual : isNotEqual);
        }

        public override string ErrorCheck() {
            if(everyFrame.Value &&
                FsmEvent.IsNullOrEmpty(isEqual) &&
                FsmEvent.IsNullOrEmpty(isNotEqual))
                return "Action sends no events!";
            return "";
        }
    }
}