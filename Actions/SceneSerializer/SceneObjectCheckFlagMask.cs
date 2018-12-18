using UnityEngine;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate SceneSerializer")]
    [Tooltip("This is for use with SceneSerializer")]
    public class SceneObjectCheckFlagMask : ComponentAction<SceneSerializer> {
        [RequiredField]
        [CheckForComponent(typeof(SceneSerializer))]
        [Tooltip("The GameObject that contains SceneSerializer.")]
        public FsmOwnerDefault gameObject;

        [RequiredField]
        public FsmString name;

        [RequiredField]
        public FsmIntMask mask;

        public FsmEvent isTrue;
        public FsmEvent isFalse;

        public FsmBool everyFrame;

        public override void Reset() {
            base.Reset();

            gameObject = null;
            name = null;
            mask = null;
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

            if(cachedComponent.CheckFlagMask(name.Value, mask.uValue)) {
                Fsm.Event(isTrue);
            }
            else {
                Fsm.Event(isFalse);
            }
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
