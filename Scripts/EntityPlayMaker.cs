using UnityEngine;
using System.Collections;

using HutongGames.PlayMaker;

[AddComponentMenu("M8/PlayMaker/Entity")]
[RequireComponent(typeof(EntityBase))]
[RequireComponent(typeof(PlayMakerFSM))]
public class EntityPlayMaker : MonoBehaviour {

    private PlayMakerFSM mFSM;
    private EntityBase mEntity;
    private bool mStarted;

    public PlayMakerFSM FSM { get { return mFSM; } }
    public EntityBase entity { get { return mEntity; } }

    void Awake() {
        mFSM = GetComponent<PlayMakerFSM>();
        mEntity = GetComponent<EntityBase>();

        //only start once we spawn
        mFSM.Fsm.RestartOnEnable = false; //not when we want to sleep/wake
        mFSM.enabled = false;

        mEntity.setStateCallback += OnEntityChangedState;
        mEntity.releaseCallback += OnEntityRelease;

        if(mEntity.activator != null) {
            mEntity.activator.awakeCallback += OnActivatorWakeUp;
            mEntity.activator.sleepCallback += OnActivatorSleep;
        }
    }

    // Use this for initialization
    void Start() {
        if(mEntity.activateOnStart) {
            mFSM.enabled = true;
            mStarted = true;
        }
    }

    void OnSpawned() {
        mFSM.Fsm.Reinitialize();
        mFSM.enabled = true;
        mStarted = true;
    }

    void OnActivatorWakeUp() {
        if(mStarted) {
            mFSM.Fsm.Event(EntityEvent.Wake);
        }
    }

    void OnActivatorSleep() {
        if(mStarted)
            mFSM.Fsm.Event(EntityEvent.Sleep);
    }

    void OnEntitySpawn(EntityBase ent) {
        mFSM.SendEvent(EntityEvent.Spawn);
    }

    void OnEntityChangedState(EntityBase ent) {
        mFSM.SendEvent(EntityEvent.StateChanged);
    }

    void OnEntityRelease(EntityBase ent) {
        mFSM.enabled = false;
    }
}
