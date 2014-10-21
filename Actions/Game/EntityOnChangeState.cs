using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Mate Entity")]
    [HutongGames.PlayMaker.Tooltip("Wait for entity to change state.")]
    public class EntityOnChangeState : FSMActionComponentBase<EntityBase> {

        [UIHint(UIHint.Variable)]
        public FsmInt stateOut;

        [UIHint(UIHint.Variable)]
        public FsmInt prevStateOut;

        public override void Reset() {
            base.Reset();

            stateOut = null;
            prevStateOut = null;
        }

        public override void OnEnter() {
            base.OnEnter();

            mComp.setStateCallback += OnEntityChangeState;
        }

        public override void OnExit() {
            mComp.setStateCallback -= OnEntityChangeState;
        }

        void OnEntityChangeState(EntityBase ent) {
            if(!stateOut.IsNone)
                stateOut.Value = ent.state;
            if(!prevStateOut.IsNone)
                prevStateOut.Value = ent.prevState;

            Finish();
        }
    }
}