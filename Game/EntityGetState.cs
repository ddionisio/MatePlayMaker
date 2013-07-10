using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Mate Entity")]
    [Tooltip("Get entity's current state.")]
    public class EntityGetState : FSMActionComponentBase<EntityBase> {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmInt output;

        public override void Reset() {
            base.Reset();

            output = null;
        }

        public override void OnEnter() {
            base.OnEnter();

            output.Value = mComp.state;

            Finish();
        }
    }
}