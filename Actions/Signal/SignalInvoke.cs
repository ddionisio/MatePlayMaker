using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Signal")]
    [Tooltip("Invoke given signal.")]
    public class SignalInvoke : FsmStateAction {
        [ObjectType(typeof(Signal))]
        [RequiredField]
        public FsmObject signal;

        public override void OnEnter() {
            var s = (Signal)signal.Value;
            s.Invoke();

            Finish();
        }
    }
}