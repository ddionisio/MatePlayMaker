using UnityEngine;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Particle System")]
    [Tooltip("Stop the particle.")]
    public class ParticleSystemStop : ComponentAction<ParticleSystem> {
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
                cachedComponent.Stop(withChildren.Value);

            Finish();
        }
    }
}
