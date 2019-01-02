using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate User Data")]
    public class UserDataGet : FsmStateAction {
        [ObjectType(typeof(UserData))]
        public FsmObject userData;

        public FsmString key;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmVar output;

        public FsmBool everyFrame;

        public override void Reset() {
            userData = null;
            key = null;
            output = null;
            everyFrame = false;
        }

        public override void OnEnter() {
            DoGet();

            if(!everyFrame.Value)
                Finish();
        }

        public override void OnUpdate() {
            DoGet();
        }

        void DoGet() {
            var ud = userData.Value as UserData;
            if(!ud)
                return;

            var keyStr = key.Value;

            switch(output.Type) {
                case VariableType.String:
                    output.stringValue = ud.GetString(keyStr);
                    break;
                case VariableType.Int:
                    output.intValue = ud.GetInt(keyStr);
                    break;
                case VariableType.Float:
                    output.floatValue = ud.GetFloat(keyStr);
                    break;
                case VariableType.Bool:
                    output.boolValue = ud.GetInt(keyStr) != 0;
                    break;
            }
        }
    }
}