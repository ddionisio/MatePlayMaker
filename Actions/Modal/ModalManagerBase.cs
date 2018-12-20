using UnityEngine;
using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Modal")]
    public abstract class ModalManagerBase : FsmStateAction {
        [DisplayOrder(0)]
        public FsmModalManager manager;

        public override void Reset() {
            manager = new FsmModalManager { from = FsmModalManager.FromType.Main };
        }

        public override string ErrorCheck() {
            if(Fsm != null && manager != null) {
                if(!manager.IsValid(Fsm))
                    return "No ModalManager.";
            }

            return "";
        }
    }
}