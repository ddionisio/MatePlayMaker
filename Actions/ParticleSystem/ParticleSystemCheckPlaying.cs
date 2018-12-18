using UnityEngine;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Particle System")]
    [Tooltip("Check if ParticleSystem is playing.")]
    public class ParticleSystemCheckPlaying : ComponentAction<ParticleSystem> {
        [RequiredField]
        [CheckForComponent(typeof(ParticleSystem))]
        [Tooltip("The GameObject that contains ParticleSystem.")]
        public FsmOwnerDefault gameObject;

        [UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        public FsmEvent isTrue;
        public FsmEvent isFalse;

        public FsmBool everyFrame;

        public override void Reset() {
            isTrue = null;
            isFalse = null;
            storeResult = null;
            everyFrame = false;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            Check();

            if(!everyFrame.Value)
                Finish();
        }

        void Check() {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(!UpdateCache(go))
                return;

            bool isPlaying = cachedComponent.isPlaying;

            if(!storeResult.IsNone)
                storeResult.Value = isPlaying;

            Fsm.Event(isPlaying ? isTrue : isFalse);
        }

        public override string ErrorCheck() {
            if(everyFrame.Value &&
                FsmEvent.IsNullOrEmpty(isTrue) &&
                FsmEvent.IsNullOrEmpty(isFalse))
                return "Action sends no events!";
            return "";
        }
    }
}
