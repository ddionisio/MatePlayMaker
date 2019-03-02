using UnityEngine;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Audio")]
    public class SoundPlaylistPlay : FsmStateAction {
        [RequiredField]
        public FsmSoundPlaylistName sound;
                
        public FsmBool wait;

        [Tooltip("If set, wait for sound to end before finishing, then enter event.")]
        [HideIf("IsNotWait")]
        public FsmEvent waitEndEvent;

        private AudioSourceProxy mSource;

        public override void Reset() {
            sound = null;
            wait = null;
            waitEndEvent = null;

            mSource = null;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            mSource = SoundPlaylist.instance.Play(sound.GetString(), false);

            if(!wait.Value)
                Finish();
        }

        public override void OnUpdate() {
            if(mSource == null || !mSource.isPlaying) {
                Fsm.Event(waitEndEvent);
                Finish();
            }
        }

        public override void OnExit() {
            mSource = null;
        }

        public bool IsNotWait() {
            return wait.IsNone || !wait.Value;
        }
    }
}
