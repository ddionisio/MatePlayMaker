using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using HutongGames.PlayMakerEditor;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [PropertyDrawer(typeof(FsmMusicPlaylistName))]
    public class FsmMusicPlaylistNamePropertyDrawer : PlayMakerEditor.PropertyDrawer {
        private static MusicPlaylist mPlaylist;

        public override object OnGUI(GUIContent label, object obj, bool isSceneObject, params object[] attributes) {
            var fsmMusicPlaylistName = (FsmMusicPlaylistName)obj;

            fsmMusicPlaylistName.from = (FsmMusicPlaylistName.FromType)EditField(" ", typeof(FsmMusicPlaylistName.FromType), fsmMusicPlaylistName.from, attributes);

            switch(fsmMusicPlaylistName.from) {
                case FsmMusicPlaylistName.FromType.Playlist:
                    if(!mPlaylist) {
                        //manually grab
                        mPlaylist = AssetDatabase.LoadAssetAtPath<MusicPlaylist>(MusicPlaylist.assetPath);
                    }

                    if(mPlaylist) {
                        //generate names
                        var musicNameList = new List<string>();
                        musicNameList.Add("<None>");
                        for(int i = 0; i < mPlaylist.music.Length; i++)
                            musicNameList.Add(mPlaylist.music[i].name);

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

                case FsmMusicPlaylistName.FromType.StringRef:
                    EditField("stringRef", " ", fsmMusicPlaylistName.stringRef, attributes);
                    break;
            }

            return obj;
        }
    }
}