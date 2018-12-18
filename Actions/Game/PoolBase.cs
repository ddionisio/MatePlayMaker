using UnityEngine;
using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Pool")]
    public abstract class PoolBase : FsmStateAction {
        [DisplayOrder(0)]
        [Tooltip("Determine pool to grab spawn.")]
        public FsmPool pool;

        public override void Reset() {
            if(Owner && Owner.GetComponent<PoolController>() != null)
                pool = new FsmPool { from = FsmPool.FromType.Owner };
            else
                pool = new FsmPool { from = FsmPool.FromType.Group };
        }

        public override string ErrorCheck() {
            if(Fsm != null && pool != null) {
                if(!pool.IsValid(Fsm))
                    return "No valid pool.";
            }

            return "";
        }
    }
}