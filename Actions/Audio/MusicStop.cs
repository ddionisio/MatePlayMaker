using UnityEngine;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Audio")]
    public class MusicStop : FsmStateAction {
        public FsmBool immediate;

        public override void Reset() {
            immediate = true;
        }
        
        // Code that runs on entering the state.
        public override void OnEnter() {
            MusicPlaylist.instance.Stop(immediate.Value);
            Finish();
        }
    }
}