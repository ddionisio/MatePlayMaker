
namespace HutongGames.PlayMaker.Actions.M8 {
    [Tooltip("Check if given modal exists in the stack.")]
    public class ModalManagerCheckModal : ModalManagerBase {
        public FsmString modal;

        public FsmEvent isTrue;
        public FsmEvent isFalse;

        [UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        public FsmBool everyFrame;

        public override void Reset() {
            base.Reset();

            modal = null;
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
                bool isInStack = mgr.IsInStack(modal.Value);

                if(!storeResult.IsNone)
                    storeResult.Value = isInStack;

                Fsm.Event(isInStack ? isTrue : isFalse);                
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