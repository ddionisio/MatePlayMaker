using UnityEngine;

namespace HutongGames.PlayMaker.Actions.M8._Rigidbody2D {
#if !M8_PHYSICS2D_DISABLED
    [ActionCategory("Mate Rigidbody2D")]
    [Tooltip("Check Rigidbody2D.simulated")]
    public class CheckSimulated : ComponentAction<Rigidbody2D> {
        [RequiredField]
        [CheckForComponent(typeof(Rigidbody2D))]
        [Tooltip("The Rigidbody2D source.")]
        public FsmOwnerDefault gameObject;

        [UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        public FsmEvent isTrue;
        public FsmEvent isFalse;

        public FsmBool everyFrame;

        public override void Reset() {
            gameObject = null;

            storeResult = null;
            isTrue = null;
            isFalse = null;

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
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(!UpdateCache(go))
                return;

            var isSimulated = cachedComponent.simulated;

            storeResult = isSimulated;

            Fsm.Event(isSimulated ? isTrue : isFalse);
        }

        public override string ErrorCheck() {
            if(everyFrame.Value &&
                FsmEvent.IsNullOrEmpty(isTrue) &&
                FsmEvent.IsNullOrEmpty(isFalse))
                return "Action sends no events!";
            return "";
        }
    }
#endif
}