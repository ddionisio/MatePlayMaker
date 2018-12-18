using UnityEngine;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Transform")]
    [Tooltip("Check if we are close to given target based on radius.")]
    public class CheckRadius : FsmStateAction {
        [RequiredField]
        [Tooltip("The GameObject source.")]
        public FsmOwnerDefault gameObject;

        [Tooltip("The GameObject to check against.")]
        public FsmGameObject targetObject;

        [Tooltip("World position to check, or local offset from Target Object if specified.")]
        public FsmVector3 targetPosition;

        public FsmFloat targetRadius;

        [UIHint(UIHint.Variable)]
        public FsmBool result;

        public FsmEvent isTrue;

        public FsmEvent isFalse;

        [Title("Draw Debug Radius")]
        [Tooltip("Draw a debug sphere for the approx. radius.")]
        public FsmBool showRadius;

        [Tooltip("Color to use for the debug sphere.")]
        public FsmColor showRadiusColor;

        [Tooltip("Repeat every frame.")]
        public FsmBool everyFrame;

        [Tooltip("Delay during update.")]
        [HideIf("IsNotEveryFrame")]
        public FsmFloat everyFrameDelay;

        private float mCurTime;

        public override void Reset() {
            gameObject = null;
            targetObject = null;
            targetPosition = new FsmVector3 { UseVariable = true };
            targetRadius = null;

            result = null;

            isTrue = null;
            isFalse = null;

            showRadius = false;
            showRadiusColor = Color.yellow;

            everyFrame = false;
            everyFrameDelay = 0f;
        }

        public override void OnEnter() {
            DoCheck();

            mCurTime = 0f;

            if(!everyFrame.Value) {
                Finish();
            }
        }

        public override void OnLateUpdate() {
            if(mCurTime < everyFrameDelay.Value)
                mCurTime += Time.deltaTime;
            else
                mCurTime = 0f;

            DoCheck();
        }

        void DoCheck() {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(go == null) {
                return;
            }


            Vector3 targetPos = GetTargetPos();
            float targetR = GetTargetRadius();

            Transform t = go.transform;

            Vector3 delta = targetPos - t.position;

            bool isNear = delta.sqrMagnitude <= targetR * targetR;

            if(!result.IsNone)
                result.Value = isNear;

            if(isNear) {
                if(!FsmEvent.IsNullOrEmpty(isTrue))
                    Fsm.Event(isTrue);
            }
            else {
                if(!FsmEvent.IsNullOrEmpty(isFalse))
                    Fsm.Event(isFalse);
            }
        }

        Vector3 GetTargetPos() {
            var goTarget = targetObject.Value;
            Vector3 targetPos;
            if(goTarget != null) {
                targetPos = !targetPosition.IsNone ? goTarget.transform.TransformPoint(targetPosition.Value) : goTarget.transform.position;
            }
            else {
                targetPos = targetPosition.Value;
            }

            return targetPos;
        }

        float GetTargetRadius() {
            return targetRadius.IsNone ? 0.0f : targetRadius.Value;
        }

        public override void OnDrawActionGizmos() {
            if(showRadius.Value) {
                float r = GetTargetRadius();
                if(r > 0.0f) {
                    Gizmos.color = showRadiusColor.Value;
                    Gizmos.DrawWireSphere(GetTargetPos(), r);
                }
            }
        }

        public bool IsNotEveryFrame() {
            return everyFrame.IsNone || !everyFrame.Value;
        }
    }
}
