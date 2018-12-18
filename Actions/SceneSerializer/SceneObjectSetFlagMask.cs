using UnityEngine;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate SceneSerializer")]
    [Tooltip("This is for use with SceneSerializer.")]
    public class SceneObjectSetFlagMask : ComponentAction<SceneSerializer> {
        [RequiredField]
        [CheckForComponent(typeof(SceneSerializer))]
        [Tooltip("The GameObject that contains SceneSerializer.")]
        public FsmOwnerDefault gameObject;

        [RequiredField]
        public FsmString name;

        [RequiredField]
        public FsmIntMask mask;

        [RequiredField]
        public FsmBool val;

        public override void Reset() {
            gameObject = null;
            name = null;
            mask = null;
            val = null;
        }

        public override void OnEnter() {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(UpdateCache(go))
                cachedComponent.SetFlagMask(name.Value, mask.uValue, val.Value);

            Finish();
        }
    }
}
