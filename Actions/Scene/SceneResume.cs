using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Scene")]
    [Tooltip("Resume the scene.")]
    public class SceneResume : FsmStateAction {
        // Code that runs on entering the state.
        public override void OnEnter() {
            SceneManager.instance.Resume();

            Finish();
        }
    }
}