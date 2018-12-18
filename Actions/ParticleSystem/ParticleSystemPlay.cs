using UnityEngine;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Particle System")]
    [Tooltip("Play the particle.")]
    public class ParticleSystemPlay : ComponentAction<ParticleSystem> {
        [RequiredField]
        [CheckForComponent(typeof(ParticleSystem))]
        [Tooltip("The GameObject that contains ParticleSystem.")]
        public FsmOwnerDefault gameObject;

        public FsmBool withChildren;

        public override void Reset() {
            withChildren = false;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(UpdateCache(go))
                cachedComponent.Play(withChildren.Value);

            Finish();
        }
    }
}
