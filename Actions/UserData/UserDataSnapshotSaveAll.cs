using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate User Data")]
    public class UserDataSnapshotSaveAll : FsmStateAction {
        [ObjectType(typeof(UserData))]
        public FsmObject userData;

        public override void Reset() {
            userData = null;
        }

        public override void OnEnter() {
            var ud = userData.Value as UserData;
            if(ud)
                ud.SnapshotSaveAll();

            Finish();
        }
    }
}