using UnityEngine;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Particle System")]
    [Tooltip("Set the loop of ParticleSystem.")]
    public class ParticleSystemSetLoop : ComponentAction<ParticleSystem> {
        [RequiredField]
        [CheckForComponent(typeof(ParticleSystem))]
        [Tooltip("The GameObject that contains ParticleSystem.")]
        public FsmOwnerDefault gameObject;

        public FsmBool loop;

        public override void Reset() {
            loop = false;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(UpdateCache(go)) {
                var data = cachedComponent.main;
                data.loop = loop.Value;
            }

            Finish();
        }
    }
}
