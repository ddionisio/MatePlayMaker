using UnityEngine;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Audio")]
    public class MusicPlay : FsmStateAction {
        [RequiredField]
        public FsmMusicPlaylistName music;

        public FsmBool loop;
        public FsmBool immediate;
        public FsmBool checkPlaying;

        public override void Reset() {
            music = null;
            loop = false;
            immediate = false;
            checkPlaying = true;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            var musicName = music.GetString();
            if(MusicPlaylist.instance.Exists(musicName)) {
                if(!checkPlaying.Value || MusicPlaylist.instance.lastPlayName != musicName)
                MusicPlaylist.instance.Play(musicName, loop.Value, immediate.Value);
            }

            Finish();
        }
    }
}