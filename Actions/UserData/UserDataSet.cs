using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate User Data")]
    public class UserDataSet : FsmStateAction {
        [ObjectType(typeof(UserData))]
        public FsmObject userData;

        public FsmString key;

        public FsmVar value;

        public override void Reset() {
            userData = null;
            key = null;
            value = null;
        }

        public override void OnEnter() {
            var ud = userData.Value as UserData;
            if(ud) {
                var keyStr = key.Value;

                switch(value.Type) {
                    case VariableType.String:
                        ud.SetString(keyStr, value.stringValue);
                        break;
                    case VariableType.Int:
                        ud.SetInt(keyStr, value.intValue);
                        break;
                    case VariableType.Float:
                        ud.SetFloat(keyStr, value.floatValue);
                        break;
                    case VariableType.Bool:
                        ud.SetInt(keyStr, value.boolValue ? 1 : 0);
                        break;
                }
            }

            Finish();
        }
    }
}