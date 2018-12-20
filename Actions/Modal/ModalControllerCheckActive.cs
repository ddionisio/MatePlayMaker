using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Modal")]
    public class ModalControllerCheckActive : ComponentAction<ModalController> {
        [RequiredField]
        [CheckForComponent(typeof(ModalController))]
        [Tooltip("The GameObject that contains ModalController.")]
        public FsmOwnerDefault gameObject;

        [UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        public FsmEvent isTrue;
        public FsmEvent isFalse;

        public FsmBool everyFrame;

        public override void Reset() {
            gameObject = null;
            isTrue = null;
            isFalse = null;
            storeResult = null;
            everyFrame = false;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            Check();

            if(!everyFrame.Value)
                Finish();
        }

        void Check() {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(!UpdateCache(go))
                return;

            bool isActive = cachedComponent.isActive;

            if(!storeResult.IsNone)
                storeResult.Value = isActive;

            Fsm.Event(isActive ? isTrue : isFalse);
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