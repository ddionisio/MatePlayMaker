using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Scene")]
    [Tooltip("Pause the scene.")]
    public class ScenePause : FsmStateAction {
        // Code that runs on entering the state.
        public override void OnEnter() {
            SceneManager.instance.Pause();

            Finish();
        }
    }
}