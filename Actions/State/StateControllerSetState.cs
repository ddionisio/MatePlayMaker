using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate State")]
    [Tooltip("Set the state of StateController.")]
    public class StateControllerSetState : ComponentAction<StateController> {
        [RequiredField]
        [CheckForComponent(typeof(StateController))]
        public FsmOwnerDefault gameObject;

        [ObjectType(typeof(State))]
        public FsmObject state;

        public override void Reset() {
            gameObject = null;
            state = null;
        }

        public override void OnEnter() {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(UpdateCache(go))
                cachedComponent.state = (State)state.Value;

            Finish();
        }
    }
}