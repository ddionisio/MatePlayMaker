using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Scene")]
    public class SceneValueChangedWait : FsmStateAction {
        [RequiredField]
        public FsmString name;

        public FsmBool global;

        [UIHint(UIHint.Variable)]
        public FsmVar output;

        public FsmEvent changeEvent;

        private bool mIsGlobal;

        public override void Reset() {
            name = null;

            global = false;

            output = null;

            changeEvent = null;
        }

        public override void OnEnter() {
            mIsGlobal = global.Value;

            if(mIsGlobal)
                SceneState.instance.global.onValueChange += StateCallback;
            else
                SceneState.instance.local.onValueChange += StateCallback;
        }

        public override void OnExit() {
            if(mIsGlobal)
                SceneState.instance.global.onValueChange -= StateCallback;
            else
                SceneState.instance.local.onValueChange -= StateCallback;
        }

        void StateCallback(string aName, SceneState.StateValue newVal) {
            if(!output.IsNone) {
                switch(output.Type) {
                    case VariableType.Int:
                        output.SetValue(newVal.ival);
                        break;
                    case VariableType.Float:
                        output.SetValue(newVal.fval);
                        break;
                    case VariableType.String:
                        output.SetValue(newVal.sval);
                        break;
                    case VariableType.Bool:
                        output.SetValue(newVal.ival != 0);
                        break;
                }
            }

            if(!FsmEvent.IsNullOrEmpty(changeEvent))
                Fsm.Event(changeEvent);

            Finish();
        }

        public override string ErrorCheck() {
            string errStr;

            if(!output.IsNone) {
                switch(output.Type) {
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
