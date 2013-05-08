using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Mate Scene")]
    public class SceneFlagListen : FsmStateAction {
        [RequiredField]
        public FsmString name;

        public bool global;

        [RequiredField]
        public FsmInt bit;

        public FsmEvent isTrue;
        public FsmEvent isFalse;

        public override void Reset() {
            name = null;
            global = false;

            bit = null;

            isTrue = null;
            isFalse = null;
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
                int mask = 1 << bit.Value;
                if((newVal.ival & mask) == mask)
                    Fsm.Event(isTrue);
                else
                    Fsm.Event(isFalse);
            }
        }

        public override string ErrorCheck() {
            if(FsmEvent.IsNullOrEmpty(isTrue) &&
                FsmEvent.IsNullOrEmpty(isFalse))
                return "Action sends no events!";
            return "";
        }
    }
}
