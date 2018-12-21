using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Localize")]
    public class LocalizeGetString : FsmStateAction {
        public FsmLocalize localize;

        [UIHint(UIHint.Variable)]
        [RequiredField]
        public FsmString output;

        public override void Reset() {
            localize = new FsmLocalize();
            output = null;
        }

        public override void OnEnter() {
            output.Value = localize.GetString();

            Finish();
        }
    }
}