using UnityEngine;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Audio")]
    [Tooltip("Play SoundPlayer.")]
    public class SoundStop : ComponentAction<SoundPlayer> {
        [RequiredField]
        [CheckForComponent(typeof(ParticleSystem))]
        [Tooltip("The GameObject that contains SoundPlayer.")]
        public FsmOwnerDefault gameObject;

        public override void OnEnter() {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(UpdateCache(go))
                cachedComponent.Stop();

            Finish();
        }
    }
}