using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [ActionCategory("Mate Input")]
    public class InputEvent : FsmStateAction {
        [ObjectType(typeof(InputAction))]
        public FsmObject input;

        public FsmEvent pressedEvent;
        public FsmEvent releasedEvent;

        public FsmBool everyFrame;

        private InputAction.ButtonState mCurState = InputAction.ButtonState.None;

        public override void Reset() {
            input = null;

            pressedEvent = null;
            releasedEvent = null;

            everyFrame = false;
        }

        public override void OnEnter() {
            mCurState = InputAction.ButtonState.None;

            EventUpdate();

            if(!everyFrame.Value)
                Finish();
        }

        public override void OnUpdate() {
            EventUpdate();
        }

        void EventUpdate() {
            if(input.IsNone || !input.Value)
                return;

            var action = (InputAction)input.Value;

            var newState = action.GetButtonState();

            //state has changed
            if(mCurState != newState) {
                mCurState = newState;

                switch(mCurState) {
                    case InputAction.ButtonState.Pressed:
                        if(!FsmEvent.IsNullOrEmpty(pressedEvent))
                            Fsm.Event(pressedEvent);
                        break;
                    case InputAction.ButtonState.Released:
                        if(!FsmEvent.IsNullOrEmpty(releasedEvent))
                            Fsm.Event(releasedEvent);
                        break;
                }
            }
        }
    }
}