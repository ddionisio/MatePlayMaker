using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Scene")]
    public class SceneFlagSet : FsmStateAction {
        [RequiredField]
        public FsmString name;

        public FsmBool global;

        [RequiredField]
        public FsmInt bit;

        [RequiredField]
        public FsmBool val;

        public FsmBool persistent;

        public override void Reset() {
            name = null;
            global = false;
            bit = null;
            val = null;
            persistent = false;
        }

        public override void OnEnter() {
            if(global.Value)
                SceneState.instance.global.SetFlag(name.Value, bit.Value, val.Value, persistent.Value);
            else
                SceneState.instance.local.SetFlag(name.Value, bit.Value, val.Value, persistent.Value);

            Finish();
        }
    }
}
