using UnityEngine;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Audio")]
    public class SoundGlobalPlay : FsmStateAction {
        [RequiredField]
        public FsmString sound;
                
        public FsmBool wait;

        [Tooltip("If set, wait for sound to end before finishing, then enter event.")]
        [HideIf("IsNotWait")]
        public FsmEvent waitEndEvent;

        public override void Reset() {
            sound = null;
            wait = null;
            waitEndEvent = null;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            if(wait.Value)
                SoundPlayerGlobal.instance.Play(sound.Value, OnSoundEnd);
            else {
                SoundPlayerGlobal.instance.Play(sound.Value);

                Finish();
            }
        }

        void OnSoundEnd(object param) {
            Fsm.Event(waitEndEvent);

            Finish();
        }

        public bool IsNotWait() {
            return wait.IsNone || !wait.Value;
        }
    }
}
