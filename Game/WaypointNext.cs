using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Mate Waypoint")]
    [Tooltip("Move waypoint to the next.")]
    public class WaypointNext : FsmStateAction {
        [RequiredField]
        [Tooltip("The waypoint data.")]
        public FsmGameObject wpHolder;

        public FsmEvent isDone;

        public bool loop = false;

        public override void Reset() {
            base.Reset();

            wpHolder = null;
            isDone = null;
            loop = false;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            base.OnEnter();

            if(!wpHolder.IsNone) {
                WaypointData wpData = (WaypointData)wpHolder.Value.GetComponent<WaypointData>();

                if(wpData.curInd >= wpData.waypoints.Count) {
                    if(loop)
                        wpData.curInd = 0;

                    Fsm.Event(isDone);
                }
                else {
                    wpData.curInd++;
                    if(wpData.curInd == wpData.waypoints.Count) {
                        if(loop)
                            wpData.curInd = 0;

                        Fsm.Event(isDone);
                    }
                }
            }

            Finish();
        }
    }
}