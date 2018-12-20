
namespace HutongGames.PlayMaker.Actions.M8 {
    [Tooltip("Check if Modal Manager is busy (opening, closing modals).")]
    public class ModalManagerCheckBusy : ModalManagerBase {
        public FsmEvent isTrue;
        public FsmEvent isFalse;

        [UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        public FsmBool everyFrame;

        public override void Reset() {
            base.Reset();

            isTrue = null;
            isFalse = null;
            storeResult = null;
            everyFrame = false;
        }

        public override void OnEnter() {
            DoCheck();

            if(!everyFrame.Value)
                Finish();
        }

        public override void OnUpdate() {
            DoCheck();
        }

        void DoCheck() {
            var mgr = manager.GetModalManager(Fsm);
            if(mgr) {
                var isBusy = mgr.isBusy;

                if(!storeResult.IsNone)
                    storeResult.Value = isBusy;

                Fsm.Event(isBusy ? isTrue : isFalse);
            }
        }

        public override string ErrorCheck() {
            var errStr = base.ErrorCheck();

            if(string.IsNullOrEmpty(errStr)) {
                if(everyFrame.Value &&
                    FsmEvent.IsNullOrEmpty(isTrue) &&
                    FsmEvent.IsNullOrEmpty(isFalse))
                    return "Action sends no events!";
            }

            return "";
        }
    }
}