using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Scene")]
    [Tooltip("Reset given value to saved UserData or default from start values.")]
    public class SceneValueReset : FsmStateAction {
        [RequiredField]
        public FsmString name;

        public FsmBool global;

        public override void Reset() {
            name = null;
            global = false;
        }

        public override void OnEnter() {
            var sceneState = global.Value ? SceneState.instance.global : SceneState.instance.local;

            sceneState.Reset(name.Value);
        }
    }
}