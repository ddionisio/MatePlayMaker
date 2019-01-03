using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Scene")]
    public class SceneValueRemove : FsmStateAction {
        [RequiredField]
        public FsmString name;

        [Tooltip("If true, also delete value from UserData")]
        public FsmBool persistent;

        public FsmBool global;

        public override void Reset() {
            name = null;
            persistent = false;
            global = false;
        }

        public override void OnEnter() {
            var sceneState = global.Value ? SceneState.instance.global : SceneState.instance.local;

            sceneState.RemoveValue(name.Value, persistent.Value);
        }
    }
}