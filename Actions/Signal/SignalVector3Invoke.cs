using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Signal")]
    [Tooltip("Invoke given signal.")]
    public class SignalVector3Invoke : FsmStateAction {
        [RequiredField]
        public FsmVector3 value;

        [ObjectType(typeof(SignalVector3))]
        [RequiredField]
        public FsmObject signal;

        public override void OnEnter() {
            var s = (SignalVector3)signal.Value;
            s.Invoke(value.Value);

            Finish();
        }
    }
}