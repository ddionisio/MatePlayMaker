using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Mate Waypoint")]
    [Tooltip("Reset waypoint to beginning.")]
    public class WaypointReset : FsmStateAction {
        [RequiredField]
        [Tooltip("The waypoint data.")]
        public FsmGameObject wpHolder;

        public override void Reset() {
            base.Reset();

            wpHolder = null;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            base.OnEnter();

            if(!wpHolder.IsNone) {
                WaypointData wpData = wpHolder.Value.GetComponent<WaypointData>();
                wpData.curInd = 0;
            }

            Finish();
        }
    }
}