using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Scene")]
    [Tooltip("Reload the current scene.")]
    public class SceneReload : FsmStateAction {
        // Code that runs on entering the state.
        public override void OnEnter() {
            SceneManager.instance.Reload();

            Finish();
        }
    }
}