using UnityEngine;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Audio")]
    [Tooltip("Play SoundPlayer.")]
    public class SoundPlay : ComponentAction<SoundPlayer> {
        [RequiredField]
        [CheckForComponent(typeof(ParticleSystem))]
        [Tooltip("The GameObject that contains SoundPlayer.")]
        public FsmOwnerDefault gameObject;

        public FsmBool wait;
        
        [Tooltip("If set, wait for sound to end before finishing, then enter event.")]
        public FsmEvent waitEndEvent;
        
        public override void Reset() {
            gameObject = null;
            wait = null;
            waitEndEvent = null;
        }

        public override void OnEnter() {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(UpdateCache(go)) {
                cachedComponent.Play();

                if(!wait.Value)
                    Finish();
            }
            else
                Finish();
        }
        
        public override void OnUpdate() {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(!UpdateCache(go))
                return;

            if(!cachedComponent.isPlaying) {
                Fsm.Event(waitEndEvent);
                Finish();
            }
        }
    }
}