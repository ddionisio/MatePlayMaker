using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate State")]
    [Tooltip("Check the current state of StateController.")]
    public class StateControllerCheckState : ComponentAction<StateController> {
        [RequiredField]
        [CheckForComponent(typeof(StateController))]
        public FsmOwnerDefault gameObject;

        [Tooltip("Compare to this state.")]
        [ObjectType(typeof(State))]
        public FsmObject state;

        [UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        public FsmEvent isTrue;
        public FsmEvent isFalse;

        public FsmBool everyFrame;

        public override void Reset() {
            gameObject = null;
            state = null;
            storeResult = null;
            isTrue = null;
            isFalse = null;
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
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(!UpdateCache(go))
                return;

            bool isEqual = cachedComponent.state == state.Value;

            if(!storeResult.IsNone)
                storeResult.Value = isEqual;

            Fsm.Event(isEqual ? isTrue : isFalse);
        }

        public override string ErrorCheck() {
            if(everyFrame.Value &&
                FsmEvent.IsNullOrEmpty(isTrue) &&
                FsmEvent.IsNullOrEmpty(isFalse))
                return "Action sends no events!";
            return "";
        }
    }
}