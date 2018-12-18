using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Scene")]
    [Tooltip("Load a new scene by level index via SceneManager.")]
    public class SceneLoadLevel : FsmStateAction {
        [RequiredField]
        public FsmInt level;

        public override void Reset() {
            level = null;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            SceneManager.instance.LoadLevel(level.Value);

            Finish();
        }
    }
}