using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using HutongGames.PlayMakerEditor;

namespace HutongGames.PlayMaker.Actions.M8 {
    [PropertyDrawer(typeof(FsmIntMask))]
    public class FsmIntMaskPropertyDrawer : PlayMakerEditor.PropertyDrawer {
        public enum Mode {
            Flags,
            Value
        }

        private string[] mMaskNames;
        private Mode mMode = Mode.Flags;

        public override object OnGUI(GUIContent label, object obj, bool isSceneObject, params object[] attributes) {
            var fsmMask = (FsmIntMask)obj;

            mMode = (Mode)EditorGUILayout.EnumPopup(" ", mMode);

            switch(mMode) {
                case Mode.Flags:
                    fsmMask.fsmInt.UseVariable = false;

                    if(mMaskNames == null) {
                        mMaskNames = new string[32];
                        for(int i = 0; i < mMaskNames.Length; i++)
                            mMaskNames[i] = i.ToString();
                    }

                    fsmMask.iValue = EditorGUILayout.MaskField(" ", fsmMask.iValue, mMaskNames);
                    break;
                case Mode.Value:
                    EditField("fsmInt", " ", fsmMask.fsmInt, attributes);
                    break;
            }

            return obj;
        }
    }
}