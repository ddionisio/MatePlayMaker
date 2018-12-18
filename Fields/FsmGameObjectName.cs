using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [System.Serializable]
    public class FsmGameObjectName {
        public enum FromType {
            GameObject,
            String
        }

        public FromType from;
        public FsmGameObject gameObject;
        public FsmString name;

        public bool IsValid() {
            switch(from) {
                case FromType.GameObject:
                    return !(gameObject == null || gameObject.IsNone || gameObject.Value == null);

                case FromType.String:
                    return !(name == null || name.IsNone || string.IsNullOrEmpty(name.Value));
            }

            return false;
        }

        public string GetName() {
            switch(from) {
                case FromType.GameObject:
                    if(gameObject == null || gameObject.IsNone || gameObject.Value == null) return "";
                    return gameObject.Value.name;

                case FromType.String:
                    if(name == null) return "";
                    return name.Value;
            }

            return "";
        }
    }
}