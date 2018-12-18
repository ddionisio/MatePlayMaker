using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Input")]
    public class InputAxis : FsmStateAction {
        [ObjectType(typeof(InputAction))]
        public FsmObject input;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmFloat output;

        public FsmBool everyFrame;

        public override void Reset() {
            input = null;
            output = null;
            everyFrame = false;
        }

        public override void OnEnter() {
            DoGetAxisValue();

            if(!everyFrame.Value)
                Finish();
        }

        public override void OnUpdate() {
            DoGetAxisValue();
        }

        void DoGetAxisValue() {
            if(input.IsNone || !input.Value)
                return;

            var action = (InputAction)input.Value;
                        
            output = action.GetAxis();
        }
    }
}