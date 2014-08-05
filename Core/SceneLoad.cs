using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Mate Scene")]
    [HutongGames.PlayMaker.Tooltip("Load a new scene by name.")]
    public class SceneLoad : FsmStateAction {
        [RequiredField]
        public FsmString scene;

        [HutongGames.PlayMaker.Tooltip("If true, then override transition effect with transitionOut and transitionIn")]
        public FsmBool transitionOverride;
        public FsmString transitionOut;
        public FsmString transitionIn;

        public override void Reset() {
            scene = null;
            transitionOverride = null;
            transitionOut = null;
            transitionIn = null;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            if(transitionOverride.Value)
                SceneManager.instance.LoadScene(scene.Value, transitionOut.Value, transitionIn.Value);
            else
                SceneManager.instance.LoadScene(scene.Value);

            Finish();
        }
    }
}