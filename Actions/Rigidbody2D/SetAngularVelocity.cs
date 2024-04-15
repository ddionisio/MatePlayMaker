using UnityEngine;

namespace HutongGames.PlayMaker.Actions.M8._Rigidbody2D {
#if !M8_PHYSICS2D_DISABLED
    [ActionCategory("Mate Rigidbody2D")]
    [Tooltip("Set Rigidbody2D.angularVelocity")]
    public class SetAngularVelocity : ComponentAction<Rigidbody2D> {
        [RequiredField]
        [CheckForComponent(typeof(Rigidbody2D))]
        [Tooltip("The Rigidbody2D source.")]
        public FsmOwnerDefault gameObject;

        public FsmFloat angle;

        public FsmBool everyFrame;

        public override void Reset() {
            gameObject = null;

            angle = null;

            everyFrame = false;
        }

        public override void Awake() {
            Fsm.HandleFixedUpdate = true;
        }

        public override void OnEnter() {
            ApplyValue();

            if(!everyFrame.Value)
                Finish();
        }

        public override void OnFixedUpdate() {
            ApplyValue();

            if(!everyFrame.Value)
                Finish();
        }

        void ApplyValue() {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(!UpdateCache(go))
                return;

            cachedComponent.angularVelocity = angle.Value;
        }
    }
#endif
}