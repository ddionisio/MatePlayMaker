using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate User Data")]
    public class UserDataSnapshotSave : FsmStateAction {
        [ObjectType(typeof(UserData))]
        public FsmObject userData;

        public FsmString key;

        public override void Reset() {
            userData = null;
            key = null;
        }

        public override void OnEnter() {
            var ud = userData.Value as UserData;
            if(ud)
                ud.SnapshotSave(key.Value);

            Finish();
        }
    }
}