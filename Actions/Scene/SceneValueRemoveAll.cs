using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Scene")]
    public class SceneValueRemoveAll : FsmStateAction {        
        [Tooltip("If true, also delete values from UserData")]
        public FsmBool persistent;

        public FsmBool global;

        public override void Reset() {
            persistent = false;
            global = false;
        }

        public override void OnEnter() {
            var sceneState = global.Value ? SceneState.instance.global : SceneState.instance.local;

            sceneState.Clear(persistent.Value);
        }
    }
}