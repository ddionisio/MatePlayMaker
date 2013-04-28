using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Mate Waypoint")]
    [Tooltip("Move waypoint backwards.")]
    public class WaypointPrevious : FsmStateAction {
        [RequiredField]
        [Tooltip("The waypoint data.")]
        public FsmGameObject wpHolder;

        public FsmEvent isFirst;

        public bool loop = false;

        public override void Reset() {
            base.Reset();

            wpHolder = null;
            isFirst = null;
            loop = false;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            base.OnEnter();

            if(!wpHolder.IsNone) {
                WaypointData wpData = wpHolder.Value.GetComponent<WaypointData>();

                if(wpData.curInd <= 0) {
                    if(loop)
                        wpData.curInd = wpData.waypoints.Count - 1;
                    else {
                        wpData.curInd = 0;
                    }

                    Fsm.Event(isFirst);
                }
                else {
                    wpData.curInd--;
                    if(wpData.curInd < 0) {
                        if(loop)
                            wpData.curInd = wpData.waypoints.Count - 1;
                        else
                            wpData.curInd = 0;

                        Fsm.Event(isFirst);
                    }
                }
            }

            Finish();
        }
    }
}