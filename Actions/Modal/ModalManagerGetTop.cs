
namespace HutongGames.PlayMaker.Actions.M8 {
    public class ModalManagerGetTop : ModalManagerBase {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmString output;

        public override void Reset() {
            base.Reset();

            output = null;
        }

        public override void OnEnter() {
            if(!output.IsNone) {
                var mgr = manager.GetModalManager(Fsm);
                if(mgr)
                    output.Value = mgr.GetTop();
            }

            Finish();
        }
    }
}