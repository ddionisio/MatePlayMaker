using UnityEngine;

namespace HutongGames.PlayMaker.Actions.M8._Rigidbody2D {
#if !M8_PHYSICS2D_DISABLED
    [ActionCategory("Mate Rigidbody2D")]
    [Tooltip("Set Rigidbody2D.simulated")]
    public class SetSimulated : ComponentAction<Rigidbody2D> {
        [RequiredField]
        [CheckForComponent(typeof(Rigidbody2D))]
        [Tooltip("The Rigidbody2D source.")]
        public FsmOwnerDefault gameObject;

        public FsmBool isSimulated;

        public override void Reset() {
            gameObject = null;
            isSimulated = null;
        }

        public override void OnEnter() {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(UpdateCache(go))
                cachedComponent.simulated = isSimulated.Value;

            Finish();
        }
    }
#endif
}