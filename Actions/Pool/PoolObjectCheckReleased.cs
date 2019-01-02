using UnityEngine;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Pool")]
    [Tooltip("Check if gameObject has been released.")]
    public class PoolObjectCheckReleased : ComponentAction<PoolDataController> {
        [RequiredField]
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

            everyFrame = false;
        }

        public override void OnEnter() {
            DoCheck();

            if(!everyFrame.Value)
                Finish();
        }

        void DoCheck() {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(!UpdateCache(go))
                return;

            var isReleased = cachedComponent.claimed;

            storeResult = isReleased;

            Fsm.Event(isReleased ? isTrue : isFalse);
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