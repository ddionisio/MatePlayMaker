
namespace HutongGames.PlayMaker.Actions.M8 {
    [Tooltip("Close all modals.")]
    public class ModalManagerCloseAll : ModalManagerBase {
        public override void OnEnter() {
            var mgr = manager.GetModalManager(Fsm);
            if(mgr)
                mgr.CloseAll();

            Finish();
        }
    }
}