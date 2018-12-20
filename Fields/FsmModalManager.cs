using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [System.Serializable]
    public class FsmModalManager {
        public enum FromType {
            Main,
            Owner,
            GameObject
        }

        public FromType from = FromType.Main;
        public FsmGameObject gameObject;

        public bool IsValid(Fsm fsm) {
            switch(from) {
                case FromType.Owner:
                    if(fsm != null && fsm.Owner)
                        return fsm.Owner.GetComponent<ModalManager>() != null;
                    break;

                case FromType.GameObject:
                    if(gameObject != null)
                        return gameObject.Value && gameObject.Value.GetComponent<ModalManager>() != null;
                    break;
            }

            return true;
        }

        public ModalManager GetModalManager(Fsm fsm) {
            switch(from) {
                case FromType.Owner:
                    return fsm.Owner ? fsm.Owner.gameObject.GetComponent<ModalManager>() : null;
                case FromType.GameObject:
                    return gameObject.Value.GetComponent<ModalManager>();
                default:
                    return ModalManager.main;
            }
        }
    }
}