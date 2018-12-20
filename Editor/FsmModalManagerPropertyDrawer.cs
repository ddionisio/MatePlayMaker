using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using HutongGames.PlayMakerEditor;

namespace HutongGames.PlayMaker.Actions.M8 {
    [PropertyDrawer(typeof(FsmModalManager))]
    public class FsmModalManagerPropertyDrawer : PlayMakerEditor.PropertyDrawer {
        public override object OnGUI(GUIContent label, object obj, bool isSceneObject, params object[] attributes) {
            var fsmModalMgr = (FsmModalManager)obj;

            fsmModalMgr.from = (FsmModalManager.FromType)EditField(" ", typeof(FsmModalManager.FromType), fsmModalMgr.from, attributes);

            switch(fsmModalMgr.from) {
                case FsmModalManager.FromType.Main:
                case FsmModalManager.FromType.Owner:
                    break;
                case FsmModalManager.FromType.GameObject:
                    EditField("gameObject", " ", fsmModalMgr.gameObject, attributes);
                    break;
            }

            return fsmModalMgr;
        }
    }
}