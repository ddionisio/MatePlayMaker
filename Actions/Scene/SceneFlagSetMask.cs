using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Scene")]
    public class SceneFlagSetMask : FsmStateAction {
        [RequiredField]
        public FsmString name;

        public FsmBool global;

        [RequiredField]
        public FsmIntMask mask;

        [RequiredField]
        public FsmBool val;

        public FsmBool persistent;

        public override void Reset() {
            name = null;
            global = false;
            mask = null;
            val = null;
            persistent = false;
        }

        public override void OnEnter() {
            if(global.Value)
                SceneState.instance.global.SetFlagMask(name.Value, mask.uValue, val.Value, persistent.Value);
            else
                SceneState.instance.local.SetFlagMask(name.Value, mask.uValue, val.Value, persistent.Value);

            Finish();
        }
    }
}
