using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Mate Scene")]
    [HutongGames.PlayMaker.Tooltip("Load a scene by level index.")]
    public class SceneLoadLevel : FsmStateAction {
        [RequiredField]
        public FsmInt level;

        [HutongGames.PlayMaker.Tooltip("If true, then override transition effect with transitionOut and transitionIn")]
        public FsmBool transitionOverride;
        public FsmString transitionOut;
        public FsmString transitionIn;

        public override void Reset() {
            level = null;
            transitionOverride = null;
            transitionOut = null;
            transitionIn = null;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            if(transitionOverride.Value)
                SceneManager.instance.LoadLevel(level.Value, transitionOut.Value, transitionIn.Value);
            else
                SceneManager.instance.LoadLevel(level.Value);

            Finish();
        }
    }
}