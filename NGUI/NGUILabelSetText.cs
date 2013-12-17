using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Mate NGUI")]
    [Tooltip("Set the text of a label.")]
    public class NGUILabelSetText : FSMActionComponentBase<UILabel> {
        [RequiredField]
        public FsmString text;

        [Tooltip("If text is a string key to localize.")]
        public bool isLocalize;
        
        public override void Reset() {
            base.Reset();
            
            text = null;
            isLocalize = false;
        }
        
        // Code that runs on entering the state.
        public override void OnEnter() {
            base.OnEnter();
            
            mComp.text = isLocalize ? GameLocalize.GetText(text.Value) : text.Value;

            Finish();
        }
        
    }
}
