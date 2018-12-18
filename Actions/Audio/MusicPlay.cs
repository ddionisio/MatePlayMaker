using UnityEngine;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Audio")]
    public class MusicPlay : FsmStateAction {
        [RequiredField]
        public FsmString music;

        public FsmBool immediate;

        [Tooltip("If this is set, this action will wait until music has finished. Make sure the given music is not set to loop!")]
        public FsmBool wait;

        [Tooltip("The event to call after music ends.")]
        [HideIf("IsNotWait")]
        public FsmEvent waitFinishEvent;

        public override void Reset() {
            music = null;
            immediate = true;
            wait = null;
            waitFinishEvent = null;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            if(MusicManager.instance.Exists(music.Value)) {
                MusicManager.instance.Play(music.Value, immediate.Value);

                if(wait.Value) {
                    MusicManager.instance.musicFinishCallback += OnMusicFinish;
                }
                else {
                    Finish();
                }
            }
            else {
                Finish();
            }
        }

        // Code that runs when exiting the state.
        public override void OnExit() {
            MusicManager.instance.musicFinishCallback -= OnMusicFinish;
        }

        void OnMusicFinish(string name) {
            if(name == music.Value) {
                Fsm.Event(waitFinishEvent);

                Finish();
            }
        }

        public bool IsNotWait() {
            return wait.IsNone || !wait.Value;
        }
    }
}