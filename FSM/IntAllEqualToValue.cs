﻿using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Mate FSM")]
    [Tooltip("Check if all given integers are equal to given value.")]
    public class IntAllEqualToValue : FsmStateAction {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        [Tooltip("The integer variables to check.")]
        public FsmInt[]
            boolVariables;
        [Tooltip("The integer value to compare with.")]
        public FsmInt
            valueCheck;
        [Tooltip("Event to send if all the integer variables are True.")]
        public FsmEvent
            sendEvent;
        [UIHint(UIHint.Variable)]
        [Tooltip("Store the result in a Bool variable.")]
        public FsmBool
            storeResult;
        [Tooltip("Repeat every frame while the state is active.")]
        public bool
            everyFrame;
        
        public override void Reset() {
            boolVariables = null;
            valueCheck = null;
            sendEvent = null;
            storeResult = null;
            everyFrame = false;
        }
        
        public override void OnEnter() {
            DoAllTrue();
            
            if(!everyFrame) {
                Finish();
            }       
        }
        
        public override void OnUpdate() {
            DoAllTrue();
        }
        
        void DoAllTrue() {
            if(boolVariables.Length == 0)
                return;
            
            var allTrue = true;
            
            for(var i = 0; i < boolVariables.Length; i++) {
                if(boolVariables[i].Value != valueCheck.Value) {
                    allTrue = false;
                    break;
                }
            }
            
            if(allTrue) {
                Fsm.Event(sendEvent);
            }
            
            storeResult.Value = allTrue;
        }
    }
}