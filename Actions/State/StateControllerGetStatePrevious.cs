using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate State")]
    [Tooltip("Get the previous state of StateController.")]
    public class StateControllerGetStatePrevious : ComponentAction<StateController> {
        [RequiredField]
        [CheckForComponent(typeof(StateController))]
        public FsmOwnerDefault gameObject;

        [UIHint(UIHint.Variable)]
        [ObjectType(typeof(State))]
        public FsmObject stateOutput;

        public FsmBool everyFrame;

        public override void Reset() {
            gameObject = null;
            stateOutput = null;
            everyFrame = false;
        }

        public override void OnEnter() {
            DoGet();

            if(!everyFrame.Value)
                Finish();
        }

        public override void OnUpdate() {
            DoGet();
        }

        void DoGet() {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(UpdateCache(go))
                stateOutput.Value = cachedComponent.prevState;
        }
    }
}