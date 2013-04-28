using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Mate Waypoint")]
    [Tooltip("Check if waypoint is done. Use this after WaypointNext")]
    public class WaypointIsComplete : FsmStateAction {
        [RequiredField]
        [Tooltip("The waypoint data.")]
        public FsmGameObject wpHolder;

        public FsmEvent isTrue;
        public FsmEvent isFalse;

        public override void Reset() {
            base.Reset();

            wpHolder = null;
            isTrue = null;
            isFalse = null;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            base.OnEnter();

            if(!wpHolder.IsNone) {
                WaypointData wpData = wpHolder.Value.GetComponent<WaypointData>();

                if(wpData.curInd >= wpData.waypoints.Count)
                    Fsm.Event(isTrue);
                else
                    Fsm.Event(isFalse);
            }

            Finish();
        }

        public override string ErrorCheck() {
            if(FsmEvent.IsNullOrEmpty(isTrue) &&
                FsmEvent.IsNullOrEmpty(isFalse))
                return "Action sends no events!";
            return "";
        }
    }
}