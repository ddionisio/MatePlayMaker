using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Scene")]
    public class SceneValueGet : FsmStateAction {
        [RequiredField]
        public FsmString name;

        public FsmBool global;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmVar toValue;

        public FsmBool everyFrame;

        public override void Reset() {
            name = null;
            global = false;
            toValue = null;
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
            var sceneState = global.Value ? SceneState.instance.global : SceneState.instance.local;

            switch(toValue.Type) {
                case VariableType.Int:
                    toValue.SetValue(sceneState.GetValue(name.Value));
                    break;
                case VariableType.Float:
                    toValue.SetValue(sceneState.GetValueFloat(name.Value));
                    break;
                case VariableType.String:
                    toValue.SetValue(sceneState.GetValueString(name.Value));
                    break;
                case VariableType.Bool:
                    toValue.SetValue(sceneState.GetValue(name.Value) != 0);
                    break;
            }
        }

        public override string ErrorCheck() {
            string errStr;

            if(!toValue.IsNone) {
                switch(toValue.Type) {
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
