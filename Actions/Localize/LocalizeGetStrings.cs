using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Localize")]
    public class LocalizeGetStrings : FsmStateAction {

        [CompoundArray("Items", "Localize", "Output")]
        public FsmLocalize[] localizes;
        [UIHint(UIHint.Variable)]
        [RequiredField]
        public FsmString[] outputs;

        public override void Reset() {
            localizes = new FsmLocalize[1];
            outputs = new FsmString[1];
        }

        public override void OnEnter() {
            for(int i = 0; i < localizes.Length; i++) {
                outputs[i].Value = localizes[i].GetString();
            }

            Finish();
        }
    }
}