using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Signal")]
    [Tooltip("Invoke given signal.")]
    public class SignalStringInvoke : FsmStateAction {
        [RequiredField]
        public FsmString value;

        [ObjectType(typeof(SignalString))]
        [RequiredField]
        public FsmObject signal;

        public override void OnEnter() {
            var s = (SignalString)signal.Value;
            s.Invoke(value.Value);

            Finish();
        }
    }
}