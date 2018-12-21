using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Localize")]
    public class LocalizeGetStringFormat : FsmStateAction {
        public FsmLocalize localize;

        public FsmVar[] parameters;

        [UIHint(UIHint.Variable)]
        [RequiredField]
        public FsmString output;

        private object[] mParmObjs;

        public override void Reset() {
            localize = new FsmLocalize();
            parameters = new FsmVar[0];
            output = null;
        }

        public override void OnEnter() {
            if(mParmObjs == null || mParmObjs.Length != parameters.Length)
                mParmObjs = new object[parameters.Length];

            for(int i = 0; i < parameters.Length; i++)
                mParmObjs[i] = parameters[i].GetValue();

            output.Value = string.Format(localize.GetString(), mParmObjs);

            Finish();
        }
    }
}