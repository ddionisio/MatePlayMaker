using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Signal")]
    [Tooltip("Invoke given signal.")]
    public class SignalFloatInvoke : FsmStateAction {
        [RequiredField]
        public FsmFloat value;

        [ObjectType(typeof(SignalFloat))]
        [RequiredField]
        public FsmObject signal;

        public override void OnEnter() {
            var s = (SignalFloat)signal.Value;
            s.Invoke(value.Value);

            Finish();
        }
    }
}