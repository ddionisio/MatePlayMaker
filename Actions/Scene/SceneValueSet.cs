using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Scene")]
    [Tooltip("Set the value to variable based on its type. Currently only: int, float, string, or bool.")]
    public class SceneValueSet : FsmStateAction {
        [RequiredField]
        public FsmString name;

        public FsmBool global;

        public FsmVar value;

        public FsmBool persistent;

        public override void Reset() {
            name = null;
            global = false;
            value = null;
            persistent = false;
        }

        public override void OnEnter() {
            if(!value.IsNone) {
                var sceneState = global.Value ? SceneState.instance.global : SceneState.instance.local;
                var isPersist = persistent.Value;

                switch(value.Type) {
                    case VariableType.Int:
                        sceneState.SetValue(name.Value, value.intValue, isPersist);
                        break;
                    case VariableType.Float:
                        sceneState.SetValueFloat(name.Value, value.floatValue, isPersist);
                        break;
                    case VariableType.String:
                        sceneState.SetValueString(name.Value, value.stringValue, isPersist);
                        break;
                    case VariableType.Bool:
                        sceneState.SetValue(name.Value, value.boolValue ? 1 : 0, isPersist);
                        break;
                }
            }

            Finish();
        }

        public override string ErrorCheck() {
            string errStr;

            if(!value.IsNone) {
                switch(value.Type) {
                    case VariableType.Int:
                    case VariableType.Float:
                    case VariableType.String:
                    case VariableType.Bool:
                        errStr = "";
                        break;
                    default:
                        errStr = "Unsupported type. Only use for: Int, Float, String, Bool";
                        break;
                }
            }
            else
                errStr = "";

            return errStr;
        }
    }
}
