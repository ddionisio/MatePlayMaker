
namespace HutongGames.PlayMaker.Actions.M8 {
    public class ModalManagerCloseUpTo : ModalManagerBase {
        [Tooltip("The modal to check.")]
        public FsmString modal;
        [Tooltip("If true, close all modals including given modal.")]
        public FsmBool isInclusive;

        public override void Reset() {
            base.Reset();

            modal = null;
            isInclusive = true;
        }

        public override void OnEnter() {
            var mgr = manager.GetModalManager(Fsm);
            if(mgr)
                mgr.CloseTop();

            Finish();
        }
    }
}