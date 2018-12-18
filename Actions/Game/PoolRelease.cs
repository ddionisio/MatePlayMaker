using UnityEngine;

namespace HutongGames.PlayMaker.Actions.M8 {
    [Tooltip("Release given target.")]
    public class PoolRelease : PoolBase {
        public FsmGameObject target;

        public override void OnEnter() {
            base.OnEnter();

            var poolCtrl = pool.GetPoolController(Fsm, false);
            if(poolCtrl)
                poolCtrl.Release(target.Value);

            Finish();
        }
    }
}