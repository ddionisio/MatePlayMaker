using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Mate Waypoint")]
    [Tooltip("Get a waypoint from given WaypointData and put it in a Vector2")]
    public class WaypointGetCurrent : FsmStateAction {
        [RequiredField]
        [Tooltip("The waypoint data.")]
        public FsmGameObject wpHolder;

        [UIHint(UIHint.Variable)]
        public FsmVector3 toVector;

        [UIHint(UIHint.Variable)]
        public FsmGameObject toGO;

        public override void Reset() {
            base.Reset();

            wpHolder = null;
            toVector = null;
            toGO = null;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            base.OnEnter();

            if(!wpHolder.IsNone) {
                WaypointData wpData = wpHolder.Value.GetComponent<WaypointData>();

                Debug.Log("Waypoint: " + wpData.waypoint + " index: " + wpData.curInd);

                if(!toVector.IsNone)
                    toVector.Value = wpData.waypoints[wpData.curInd].position;

                if(!toGO.IsNone)
                    toGO.Value = wpData.waypoints[wpData.curInd].gameObject;
            }

            Finish();
        }
    }
}