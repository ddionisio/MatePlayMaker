using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using HutongGames.PlayMakerEditor;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [PropertyDrawer(typeof(FsmLocalize))]
    public class FsmLocalizePropertyDrawer : PlayMakerEditor.PropertyDrawer {

        private int[] mKeyInds;

        public override object OnGUI(GUIContent label, object obj, bool isSceneObject, params object[] attributes) {
            var fsmLoc = (FsmLocalize)obj;

            fsmLoc.from = (FsmLocalize.FromType)EditField(" ", typeof(FsmLocalize.FromType), fsmLoc.from, attributes);

            switch(fsmLoc.from) {
                case FsmLocalize.FromType.Localize:
                    //make sure a localize asset exists
                    if(!LocalizeEdit.isLocalizeFileExists) {
                        GUILayout.Label(Localize.assetPath + " not found.");
                    }
                    else {
                        var loc = Localize.instance;
                        var locKeys = loc.GetKeysCustom("- None -");

                        if(mKeyInds == null || mKeyInds.Length != locKeys.Length) {
                            mKeyInds = new int[locKeys.Length];
                            for(int i = 0; i < locKeys.Length; i++)
                                mKeyInds[i] = i;
                        }

                        var curStringVal = fsmLoc.stringRef.Value;

                        int selectInd = 0;

                        if(!string.IsNullOrEmpty(curStringVal)) {
                            for(int i = 0; i < locKeys.Length; i++) {
                                if(curStringVal == locKeys[i]) {
                                    selectInd = i;
                                    break;
                                }
                            }
                        }

                        GUILayout.BeginHorizontal();

                        selectInd = EditorGUILayout.IntPopup(" ", selectInd, locKeys, mKeyInds);

                        if(GUILayout.Button(new GUIContent("E", "Configure localization."), GUILayout.Width(24f))) {
                            Selection.activeObject = loc;
                        }

                        GUILayout.EndHorizontal();

                        fsmLoc.stringRef.UseVariable = false;
                        fsmLoc.stringRef.Value = selectInd > 0 ? locKeys[selectInd] : "";
                    }
                    break;

                case FsmLocalize.FromType.StringRef:
                    EditField("stringRef", " ", fsmLoc.stringRef, attributes);
                    break;
            }

            return obj;
        }
    }
}