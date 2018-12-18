using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Signal")]
    [Tooltip("Invoke given signal state.")]
    public class SignalStateInvoke : FsmStateAction {
        [ObjectType(typeof(State))]
        public FsmObject state;

        [ObjectType(typeof(SignalState))]
        [RequiredField]
        public FsmObject signal;

        public override void OnEnter() {
            var s = (SignalState)signal.Value;
            s.Invoke((State)state.Value);

            Finish();
        }
    }
}