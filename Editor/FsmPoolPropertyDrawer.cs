using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using HutongGames.PlayMakerEditor;

namespace HutongGames.PlayMaker.Actions.M8 {
    [PropertyDrawer(typeof(FsmPool))]
    public class FsmPoolPropertyDrawer : PlayMakerEditor.PropertyDrawer {
        public override object OnGUI(GUIContent label, object obj, bool isSceneObject, params object[] attributes) {
            var fsmPool = (FsmPool)obj;

            fsmPool.from = (FsmPool.FromType)EditField(" ", typeof(FsmPool.FromType), fsmPool.from, attributes);

            switch(fsmPool.from) {
                case FsmPool.FromType.Owner:
                    fsmPool.gameObject = null;
                    fsmPool.groupName = null;
                    break;
                case FsmPool.FromType.GameObject:
                    EditField("gameObject", " ", fsmPool.gameObject, attributes);
                    fsmPool.groupName = null;
                    break;
                case FsmPool.FromType.Group:
                    EditField("groupName", " ", fsmPool.groupName, attributes);
                    fsmPool.gameObject = null;
                    break;
            }
            
            return obj;
        }
    }
}