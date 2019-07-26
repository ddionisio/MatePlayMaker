using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [Tooltip("Open a modal.")]
    public class ModalManagerOpen : ModalManagerBase {
        public FsmString modal;
        [Tooltip("If true, wait for modal to close to finish.")]
        public FsmBool waitClose;

        [CompoundArray("Parameters", "Name", "Object")]
        public FsmString[] paramNames;
        public FsmVar[] paramObjects;
                
        private GenericParams mParams = new GenericParams();

        private ModalManager mMgr;

        public override void Reset() {
            base.Reset();

            modal = null;
            waitClose = false;

            paramNames = new FsmString[0];
            paramObjects = new FsmVar[0];
        }

        public override void OnEnter() {
            //setup parameters
            for(int i = 0; i < paramNames.Length; i++) {
                var parmName = paramNames[i].Value;
                if(!string.IsNullOrEmpty(parmName))
                    mParams[parmName] = paramObjects[i].GetValue();
            }

            mMgr = manager.GetModalManager(Fsm);
            if(mMgr) {
                mMgr.Open(modal.Value, mParams);

                if(!waitClose.Value)
                    Finish();
            }
            else
                Finish();
        }

        public override void OnUpdate() {
            if(mMgr == null || !(mMgr.isBusy || mMgr.IsInStack(modal.Value)))
                Finish();
        }
    }
}