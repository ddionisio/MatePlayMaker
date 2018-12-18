using UnityEngine;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate SceneSerializer")]
    [Tooltip("This is for use with SceneSerializer. Mark object as removed, ensuring that it will not be on the scene the next time it is loaded.")]
    public class SceneObjectMarkRemove : ComponentAction<SceneSerializer> {
        [RequiredField]
        [CheckForComponent(typeof(SceneSerializer))]
        [Tooltip("The GameObject that contains SceneSerializer.")]
        public FsmOwnerDefault gameObject;

        public override void Reset() {
            gameObject = null;
        }

        public override void OnEnter() {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(UpdateCache(go))
                cachedComponent.MarkRemove();

            Finish();
        }
    }
}
