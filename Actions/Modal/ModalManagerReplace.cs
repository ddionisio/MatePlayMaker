using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [Tooltip("Close all modals and open this one.")]
    public class ModalManagerReplace : ModalManagerBase {
        public FsmString modal;

        [CompoundArray("Parameters", "Name", "Object")]
        public FsmString[] paramNames;
        public FsmVar[] paramObjects;

        private GenericParams mParams = new GenericParams();

        public override void Reset() {
            base.Reset();

            modal = null;

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

            var mgr = manager.GetModalManager(Fsm);
            if(mgr)
                mgr.Replace(modal.Value, mParams);

            Finish();
        }
    }
}