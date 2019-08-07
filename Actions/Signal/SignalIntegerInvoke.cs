using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Signal")]
    [Tooltip("Invoke given signal.")]
    public class SignalIntegerInvoke : FsmStateAction {
        [RequiredField]
        public FsmInt value;

        [ObjectType(typeof(SignalInteger))]
        [RequiredField]
        public FsmObject signal;

        public override void OnEnter() {
            var s = (SignalInteger)signal.Value;
            s.Invoke(value.Value);

            Finish();
        }
    }
}