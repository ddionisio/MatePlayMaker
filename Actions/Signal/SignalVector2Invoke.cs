using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Signal")]
    [Tooltip("Invoke given signal.")]
    public class SignalVector2Invoke : FsmStateAction {
        [RequiredField]
        public FsmVector2 value;

        [ObjectType(typeof(SignalVector2))]
        [RequiredField]
        public FsmObject signal;

        public override void OnEnter() {
            var s = (SignalVector2)signal.Value;
            s.Invoke(value.Value);

            Finish();
        }
    }
}