using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Mate Scene")]
    public class SceneValueGet : FsmStateAction {
        [RequiredField]
        public FsmString name;

        public bool global;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmInt toValue;

        public override void Reset() {
            name = null;
            global = false;
            toValue = null;
        }

        public override void OnEnter() {
            if(SceneState.instance != null) {
                toValue.Value = global ? SceneState.instance.GetGlobalValue(name.Value) : SceneState.instance.GetValue(name.Value);
            }

            Finish();
        }
    }
}
