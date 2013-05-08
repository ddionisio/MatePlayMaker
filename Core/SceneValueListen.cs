using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Mate Scene")]
    public class SceneValueListen : FsmStateAction {
        [RequiredField]
        public FsmString name;

        public bool global;

        [RequiredField]
        public FsmInt val;

        public FsmEvent isEqual;
        public FsmEvent isLess;
        public FsmEvent isGreater;

        public override void Reset() {
            name = null;
            global = false;

            val = null;

            isEqual = null;
            isLess = null;
            isGreater = null;
        }

        public override void OnEnter() {
            if(SceneState.instance != null) {
                SceneState.instance.onValueChange += StateCallback;
            }
            else {
                Finish();
            }
        }

        public override void OnExit() {
            if(SceneState.instance != null) {
                SceneState.instance.onValueChange -= StateCallback;
            }
        }

        void StateCallback(bool aGlobal, string aName, SceneState.StateValue newVal) {
            if(global == aGlobal && name.Value == aName) {
                if(val.Value == newVal.ival)
                    Fsm.Event(isEqual);
                else if(val.Value < newVal.ival)
                    Fsm.Event(isLess);
                else
                    Fsm.Event(isGreater);
            }
        }

        public override string ErrorCheck() {
            if(FsmEvent.IsNullOrEmpty(isEqual) &&
                FsmEvent.IsNullOrEmpty(isGreater) &&
                FsmEvent.IsNullOrEmpty(isLess))
                return "Action sends no events!";
            return "";
        }
    }
}
