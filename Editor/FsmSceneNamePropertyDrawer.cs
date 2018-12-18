using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using HutongGames.PlayMakerEditor;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [PropertyDrawer(typeof(FsmSceneName))]
    public class FsmSceneNamePropertyDrawer : PlayMakerEditor.PropertyDrawer {
        public enum Mode {
            FromBuild,
            Value
        }

        private string[] mNames;
        private string[] mPaths;
        private Mode mMode = Mode.FromBuild;
        
        public override object OnGUI(GUIContent label, object obj, bool isSceneObject, params object[] attributes) {
            var fsmSceneName = (FsmSceneName)obj;

            mMode = (Mode)EditorGUILayout.EnumPopup(" ", mMode);

            switch(mMode) {
                case Mode.FromBuild:
                    fsmSceneName.Name.UseVariable = false;

                    if(mNames == null) {
                        var scenes = EditorBuildSettings.scenes;

                        mNames = new string[scenes.Length + 1];
                        mPaths = new string[scenes.Length + 1];

                        mNames[0] = "None";
                        mPaths[0] = "";

                        for(int i = 0; i < scenes.Length; i++) {
                            mNames[i + 1] = SceneAssetPath.LoadableName(scenes[i].path);
                            mPaths[i + 1] = scenes[i].path;
                        }
                    }

                    var ind = System.Array.IndexOf(mNames, fsmSceneName.Name.Value);
                    if(ind == -1)
                        ind = 0;

                    var newInd = EditorGUILayout.Popup(" ", ind, mNames);

                    if(newInd != ind) {
                        fsmSceneName.Name = newInd > 0 ? mNames[newInd] : "";
                        fsmSceneName.Path = mPaths[newInd];
                    }
                    break;
                case Mode.Value:
                    EditField("Name", " ", fsmSceneName.Name, attributes);
                    fsmSceneName.Path = "";
                    break;
            }

            return obj;
        }
    }
}