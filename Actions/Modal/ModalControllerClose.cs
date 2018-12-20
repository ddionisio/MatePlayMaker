using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Modal")]
    public class ModalControllerClose : ComponentAction<ModalController> {
        [RequiredField]
        [CheckForComponent(typeof(ModalController))]
        [Tooltip("The GameObject that contains ModalController.")]
        public FsmOwnerDefault gameObject;

        public override void Reset() {
            gameObject = null;
        }

        public override void OnEnter() {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(UpdateCache(go))
                cachedComponent.Close();

            Finish();
        }
    }
}