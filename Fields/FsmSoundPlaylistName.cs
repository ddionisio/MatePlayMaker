
namespace HutongGames.PlayMaker.Actions.M8 {
    [System.Serializable]
    public class FsmSoundPlaylistName {
        public enum FromType {
            Playlist,
            StringRef
        }

        public FromType from = FromType.Playlist;
        public FsmString stringRef = new FsmString();

        public string GetString() {
            return stringRef.Value;
        }
    }
}