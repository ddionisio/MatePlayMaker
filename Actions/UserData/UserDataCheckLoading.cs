using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate User Data")]
    public class UserDataCheckLoading : FsmStateAction {
        [ObjectType(typeof(UserData))]
        public FsmObject userData;

        [UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        public FsmEvent isTrue;
        public FsmEvent isFalse;

        public FsmBool everyFrame;

        public override void Reset() {
            userData = null;
            isTrue = null;
            isFalse = null;
            storeResult = null;
            everyFrame = false;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            Check();

            if(!everyFrame.Value)
                Finish();
        }

        void Check() {
            var ud = userData.Value as UserData;
            if(!ud)
                return;

            bool isLoading = !ud.isLoaded;

            if(!storeResult.IsNone)
                storeResult.Value = isLoading;

            Fsm.Event(isLoading ? isTrue : isFalse);
        }

        public override string ErrorCheck() {
            if(everyFrame.Value &&
                FsmEvent.IsNullOrEmpty(isTrue) &&
                FsmEvent.IsNullOrEmpty(isFalse))
                return "Action sends no events!";
            return "";
        }
    }
}