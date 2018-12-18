using UnityEngine;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate SceneSerializer")]
    [Tooltip("This is for use with SceneSerializer. Supported type: int, float, string, bool (int != 0)")]
    public class SceneObjectSetValue : ComponentAction<SceneSerializer> {
        [RequiredField]
        [CheckForComponent(typeof(SceneSerializer))]
        [Tooltip("The GameObject that contains SceneSerializer.")]
        public FsmOwnerDefault gameObject;

        [RequiredField]
        public FsmString name;

        public FsmVar value;

        public override void Reset() {
            gameObject = null;
            name = null;
            value = null;
        }

        public override void OnEnter() {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(UpdateCache(go)) {
                switch(value.Type) {
                    case VariableType.Int:
                        cachedComponent.SetInt(name.Value, value.intValue);
                        break;
                    case VariableType.Float:
                        cachedComponent.SetFloat(name.Value, value.floatValue);
                        break;
                    case VariableType.String:
                        cachedComponent.SetString(name.Value, value.stringValue);
                        break;
                    case VariableType.Bool:
                        cachedComponent.SetInt(name.Value, value.boolValue ? 1 : 0);
                        break;
                }
            }                

            Finish();
        }
    }
}
