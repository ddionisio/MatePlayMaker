using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Scene")]
    [Tooltip("Load a new scene by name.")]
    public class SceneLoad : FsmStateAction {
        [RequiredField]
        public FsmSceneName scene;
                
        public override void Reset() {
            scene = null;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            SceneManager.instance.LoadScene(scene.Name.Value);

            Finish();
        }
    }
}