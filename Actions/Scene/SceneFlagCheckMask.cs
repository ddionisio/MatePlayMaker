using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Scene")]
    public class SceneFlagCheckMask : FsmStateAction {
        [RequiredField]
        public FsmString name;

        public FsmBool global;

        public FsmIntMask mask;

        [UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        public FsmEvent isTrue;
        public FsmEvent isFalse;

        public FsmBool everyFrame;

        public override void Reset() {
            name = null;
            global = false;
            mask = null;
            isTrue = null;
            isFalse = null;
            everyFrame = false;
        }

        public override void OnEnter() {
            DoCheck();

            if(!everyFrame.Value)
                Finish();
        }

        public override void OnUpdate() {
            DoCheck();
        }

        void DoCheck() {
            var isFlagged = global.Value ? SceneState.instance.global.CheckFlagMask(name.Value, mask.uValue) : SceneState.instance.local.CheckFlagMask(name.Value, mask.uValue);

            storeResult = isFlagged;

            Fsm.Event(isFlagged ? isTrue : isFalse);
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
