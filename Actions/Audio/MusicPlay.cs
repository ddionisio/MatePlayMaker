using UnityEngine;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Audio")]
    public class MusicPlay : FsmStateAction {
        [RequiredField]
        public FsmMusicPlaylistName music;

        public FsmBool loop;
        public FsmBool immediate;

        public override void Reset() {
            music = null;
            loop = false;
            immediate = true;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            if(MusicPlaylist.instance.Exists(music.GetString())) {
                MusicPlaylist.instance.Play(music.GetString(), loop.Value, immediate.Value);
            }

            Finish();
        }
    }
}