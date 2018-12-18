using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [System.Serializable]
    public class FsmPool {
        public enum FromType {
            Owner,
            GameObject,
            Group
        }

        public FromType from;
        public FsmGameObject gameObject;
        public FsmString groupName;

        public bool IsValid(Fsm fsm) {
            switch(from) {
                case FromType.Owner:
                    if(fsm == null) return false;
                    if(fsm.Owner == null) return false;
                    return fsm.Owner.GetComponent<PoolController>() != null;

                case FromType.GameObject:
                    if(gameObject == null) return false;
                    if(gameObject.IsNone || gameObject.Value == null) return false;
                    return gameObject.Value.GetComponent<PoolController>() != null;

                case FromType.Group:
                    if(groupName == null) return false;
                    return !(groupName.IsNone || string.IsNullOrEmpty(groupName.Value));
            }

            return false;
        }

        public PoolController GetPoolController(Fsm fsm, bool createIfNotFound) {
            PoolController poolCtrl = null;

            switch(from) {
                case FromType.Owner:
                    if(fsm == null) return null;
                    if(fsm.Owner == null) return null;

                    poolCtrl = fsm.Owner.GetComponent<PoolController>();
                    if(!poolCtrl && createIfNotFound)
                        poolCtrl = fsm.Owner.gameObject.AddComponent<PoolController>();
                    break;

                case FromType.GameObject:
                    if(gameObject == null) return null;
                    if(gameObject.IsNone || gameObject.Value == null) return null;

                    poolCtrl = gameObject.Value.GetComponent<PoolController>();
                    if(!poolCtrl && createIfNotFound)
                        poolCtrl = gameObject.Value.AddComponent<PoolController>();
                    break;

                case FromType.Group:
                    if(groupName == null) return null;
                    if(groupName.IsNone || string.IsNullOrEmpty(groupName.Value)) return null;

                    poolCtrl = PoolController.GetPool(groupName.Value);
                    if(!poolCtrl && createIfNotFound)
                        poolCtrl = PoolController.CreatePool(groupName.Value);
                    break;
            }

            return poolCtrl;
        }
    }
}