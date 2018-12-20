
namespace HutongGames.PlayMaker.Actions.M8 {
    [Tooltip("Close the top modal.")]
    public class ModalManagerCloseTop : ModalManagerBase {
        public override void OnEnter() {
            var mgr = manager.GetModalManager(Fsm);
            if(mgr)
                mgr.CloseTop();

            Finish();
        }
    }
}