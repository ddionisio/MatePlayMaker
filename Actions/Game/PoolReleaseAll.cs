using UnityEngine;

namespace HutongGames.PlayMaker.Actions.M8 {
    [Tooltip("Release all spawned objects from given pool.")]
    public class PoolReleaseAll : PoolBase {
        
        public override void OnEnter() {
            base.OnEnter();

            var poolCtrl = pool.GetPoolController(Fsm, false);
            if(poolCtrl)
                poolCtrl.ReleaseAll();

            Finish();
        }
    }
}