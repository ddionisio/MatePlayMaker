using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Scene")]
    public class SceneValueResetAll : FsmStateAction {
        public FsmBool global;

        public override void Reset() {
            global = false;
        }

        public override void OnEnter() {
            var sceneState = global.Value ? SceneState.instance.global : SceneState.instance.local;

            sceneState.Reset();
        }
    }
}