using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using HutongGames.PlayMakerEditor;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [PropertyDrawer(typeof(FsmSoundPlaylistName))]
    public class FsmSoundPlaylistNamePropertyDrawer : PlayMakerEditor.PropertyDrawer {
        private static SoundPlaylist mPlaylist;

        public override object OnGUI(GUIContent label, object obj, bool isSceneObject, params object[] attributes) {
            var fsmMusicPlaylistName = (FsmSoundPlaylistName)obj;

            fsmMusicPlaylistName.from = (FsmSoundPlaylistName.FromType)EditField(" ", typeof(FsmSoundPlaylistName.FromType), fsmMusicPlaylistName.from, attributes);

            switch(fsmMusicPlaylistName.from) {
                case FsmSoundPlaylistName.FromType.Playlist:
                    if(!mPlaylist) {
                        //manually grab
                        var objects = Resources.FindObjectsOfTypeAll<SoundPlaylist>();
                        if(objects.Length > 0) {
                            mPlaylist = objects[0];
                        }
                    }

                    if(mPlaylist) {
                        //generate names
                        var musicNameList = new List<string>();
                        musicNameList.Add("<None>");
                        for(int i = 0; i < mPlaylist.sounds.Length; i++)
                            musicNameList.Add(mPlaylist.sounds[i].name);

                        var curMusicName = fsmMusicPlaylistName.GetString();

                        //get current take name list index
                        int index = -1;
                        if(string.IsNullOrEmpty(curMusicName)) {
                            index = 0;
                        }
                        else {
                            for(int i = 1; i < musicNameList.Count; i++) {
                                if(musicNameList[i] == curMusicName) {
                                    index = i;
                                    break;
                                }
                            }
                        }

                        //select
                        fsmMusicPlaylistName.stringRef.UseVariable = false;

                        index = EditorGUILayout.Popup(" ", index, musicNameList.ToArray());
                        if(index >= 1 && index < musicNameList.Count)
                            fsmMusicPlaylistName.stringRef.Value = musicNameList[index];
                        else
                            fsmMusicPlaylistName.stringRef.Value = "";
                    }
                    else
                        EditField("stringRef", " ", fsmMusicPlaylistName.stringRef, attributes);
                    break;

                case FsmSoundPlaylistName.FromType.StringRef:
                    EditField("stringRef", " ", fsmMusicPlaylistName.stringRef, attributes);
                    break;
            }

            return obj;
        }
    }
}