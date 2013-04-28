using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Mate Waypoint")]
    [Tooltip("Get a waypoint from the waypoint manager and stuff it in an FsmObject. Do this sparingly, ie. on start or cache the ones you need.")]
    public class WaypointGetByName : FsmStateAction {
        [RequiredField]
        public FsmString waypoint;

        [RequiredField]
        [Tooltip("Store the object WaypointData. You can check afterwards for null if it exists.")]
        public FsmGameObject wpHolder;

        public FsmEvent onInvalid;

        public override void Reset() {
            base.Reset();

            waypoint = null;
            wpHolder = null;
            onInvalid = null;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            base.OnEnter();

            WaypointData dat = wpHolder.Value.GetComponent<WaypointData>();

            if(!WaypointManager.instance.SetWaypointData(waypoint.Value, dat)) {
                LogWarning("Waypoint: " + waypoint + " was not found!");

                if(!FsmEvent.IsNullOrEmpty(onInvalid))
                    Fsm.Event(onInvalid);
            }

            Finish();
        }
    }
}