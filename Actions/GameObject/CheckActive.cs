using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.M8._GameObject {
    [ActionCategory("Mate GameObject")]
    [ActionTarget(typeof(GameObject), "gameObject")]
    [Tooltip("Check if GameObject is active.")]
    public class CheckActive : FsmStateAction {
        [RequiredField]
        [Tooltip("The GameObject to test.")]
        public FsmGameObject gameObject;

        public FsmBool inHierarchy;

        [Tooltip("Event to send if the GameObject is active.")]
        public FsmEvent trueEvent;

        [Tooltip("Event to send if the GameObject is NOT active.")]
        public FsmEvent falseEvent;

        [UIHint(UIHint.Variable)]
        [Tooltip("Store the result in a bool variable.")]
        public FsmBool storeResult;

        public FsmBool everyFrame;

        public override void Reset() {
            gameObject = null;
            inHierarchy = true;
            trueEvent = null;
            falseEvent = null;
            storeResult = null;
            everyFrame = false;
        }

        public override void OnEnter() {
            DoIsVisible();

            if(!everyFrame.Value) {
                Finish();
            }
        }

        public override void OnUpdate() {
            DoIsVisible();
        }

        void DoIsVisible() {
            var go = gameObject.Value;

            var isActive = go && (inHierarchy.Value ? go.activeInHierarchy : go.activeSelf);
            storeResult.Value = isActive;
            Fsm.Event(isActive ? trueEvent : falseEvent);
        }
    }
}