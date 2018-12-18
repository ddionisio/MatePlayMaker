using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using HutongGames.PlayMakerEditor;

namespace HutongGames.PlayMaker.Actions.M8 {
    [PropertyDrawer(typeof(FsmGameObjectName))]
    public class FsmGameObjectNamePropertyDrawer : PlayMakerEditor.PropertyDrawer {
        public override object OnGUI(GUIContent label, object obj, bool isSceneObject, params object[] attributes) {
            var fsmGameObjectName = (FsmGameObjectName)obj;

            fsmGameObjectName.from = (FsmGameObjectName.FromType)EditField(" ", typeof(FsmGameObjectName.FromType), fsmGameObjectName.from, attributes);

            switch(fsmGameObjectName.from) {
                case FsmGameObjectName.FromType.GameObject:
                    EditField("gameObject", " ", fsmGameObjectName.gameObject, attributes);
                    fsmGameObjectName.name = null;
                    break;

                case FsmGameObjectName.FromType.String:
                    EditField("name", " ", fsmGameObjectName.name, attributes);
                    fsmGameObjectName.gameObject = null;
                    break;
            }

            return obj;
        }
    }
}