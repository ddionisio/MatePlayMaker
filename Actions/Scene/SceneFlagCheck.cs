using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Scene")]
    public class SceneFlagCheck : FsmStateAction {
        [RequiredField]
        public FsmString name;

        public FsmBool global;

        [RequiredField]
        public FsmInt bit;

        [UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        public FsmEvent isTrue;
        public FsmEvent isFalse;

        public FsmBool everyFrame;

        public override void Reset() {
            name = null;
            global = false;
            bit = null;
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
            var isFlagged = global.Value ? SceneState.instance.global.CheckFlag(name.Value, bit.Value) : SceneState.instance.local.CheckFlag(name.Value, bit.Value);

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
