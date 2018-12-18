using UnityEngine;

namespace HutongGames.PlayMaker.Actions.M8 {
    [Tooltip("Release all spawned objects based on type from given pool.")]
    public class PoolReleaseAllByType : PoolBase {
        [Tooltip("The type from Pool to release. If using GameObject, make sure this matches from Pool.")]
        public FsmGameObjectName template;

        public override void OnEnter() {
            base.OnEnter();

            var poolCtrl = pool.GetPoolController(Fsm, false);
            if(poolCtrl)
                poolCtrl.ReleaseAllByType(template.GetName());

            Finish();
        }

        public override string ErrorCheck() {
            var errStr = base.ErrorCheck();
            if(string.IsNullOrEmpty(errStr)) {
                if(template != null && !template.IsValid())
                    errStr = "Template is empty.";
            }

            return errStr;
        }
    }
}