using UnityEngine;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate SceneSerializer")]
    [Tooltip("This is for use with SceneSerializer. Supported type: int, float, string, bool (int != 0)")]
    public class SceneObjectGetValue : ComponentAction<SceneSerializer> {
        [RequiredField]
        [CheckForComponent(typeof(SceneSerializer))]
        [Tooltip("The GameObject that contains SceneSerializer.")]
        public FsmOwnerDefault gameObject;

        [RequiredField]
        public FsmString name;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmVar toValue;

        public FsmBool everyFrame;

        public override void Reset() {
            gameObject = null;
            name = null;
            toValue = null;
            everyFrame = false;
        }

        public override void OnEnter() {
            DoGetValue();

            if(!everyFrame.Value)
                Finish();
        }

        public override void OnUpdate() {
            DoGetValue();
        }

        void DoGetValue() {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(!UpdateCache(go))
                return;

            switch(toValue.Type) {
                case VariableType.Int:
                    toValue.intValue = cachedComponent.GetInt(name.Value);
                    break;
                case VariableType.Float:
                    toValue.floatValue = cachedComponent.GetFloat(name.Value);
                    break;
                case VariableType.String:
                    toValue.stringValue = cachedComponent.GetString(name.Value);
                    break;
                case VariableType.Bool:
                    toValue.boolValue = cachedComponent.GetInt(name.Value) != 0;
                    break;
            }
        }
    }
}
