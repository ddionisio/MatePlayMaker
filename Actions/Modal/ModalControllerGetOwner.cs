using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Modal")]
    [Tooltip("Get the ModalManager of this modal (owner).")]
    public class ModalControllerGetOwner : ComponentAction<ModalController> {
        [RequiredField]
        [CheckForComponent(typeof(ModalController))]
        [Tooltip("The GameObject that contains ModalController.")]
        public FsmOwnerDefault gameObject;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmGameObject output;

        public override void Reset() {
            gameObject = null;
            output = null;
        }

        public override void OnEnter() {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(UpdateCache(go) && cachedComponent.owner)
                output.Value = cachedComponent.owner.gameObject;

            Finish();
        }
    }
}