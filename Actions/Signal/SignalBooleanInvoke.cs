using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Signal")]
    [Tooltip("Invoke given signal.")]
    public class SignalBooleanInvoke : FsmStateAction {
        [RequiredField]
        public FsmBool value;

        [ObjectType(typeof(SignalBoolean))]
        [RequiredField]
        public FsmObject signal;

        public override void OnEnter() {
            var s = (SignalBoolean)signal.Value;
            s.Invoke(value.Value);

            Finish();
        }
    }
}