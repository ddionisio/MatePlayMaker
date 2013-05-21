using UnityEngine;
using System.Collections.Generic;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Mate UI")]
    [Tooltip("Opens a character dialog")]
    public class UIModalOpenCharacterDialog : FsmStateAction
    {
        [Tooltip("If empty, will use the default modal reference name")]
        public FsmString modalRef;

        [Tooltip("If name, text, and choices are references to the localizer. default = true")]
        public FsmBool isLocalize;

        [Tooltip("Close the dialog after player selects a choice, or just clicks on the dialog")]
        public FsmBool closeOnAction;

        [Tooltip("The event to set to after a choice is selected, or after click on dialog")]
        public FsmEvent actionEvent;


        public FsmString name;
        
        [RequiredField]
        public FsmString text;
                
        public FsmString portrait;

        [Tooltip("comma separate choices")]
        public FsmString choices;

        [UIHint(UIHint.Variable)]
        public FsmInt choiceOutput;

        public FsmString choiceSceneStateOutput;
        public FsmBool choiceSceneStateGlobal;
        public FsmBool choiceSceneStatePersist;

        public override void Reset() {
            base.Reset();

            modalRef = null;
            name = null;
            text = null;
            portrait = null;
            choices = null;

            choiceOutput = null;

            choiceSceneStateOutput = null;
            choiceSceneStateGlobal = null;
            choiceSceneStatePersist = null;

            isLocalize = true;
            closeOnAction = false;

            actionEvent = null;
        }

	    // Code that runs on entering the state.
	    public override void OnEnter()
	    {
            List<string> choiceSepsFilter = null;

            if(!choices.IsNone) {
                string[] choiceSeps = choices.Value.Split(',');

                choiceSepsFilter = new List<string>(choiceSeps.Length);

                for(int i = 0; i < choiceSeps.Length; i++) {
                    string trimmed = choiceSeps[i].Trim();
                    if(trimmed.Length > 0)
                        choiceSepsFilter.Add(trimmed);
                }
            }

            UIModalCharacterDialog dlg = UIModalCharacterDialog.Open(
                modalRef.IsNone ? UIModalCharacterDialog.defaultModalRef : modalRef.Value, 
                text.Value, 
                name.Value, 
                portrait.Value, 
                choiceSepsFilter.ToArray());

            if(dlg != null) {
                dlg.actionCallback += OnAction;
            }
            else {
                Finish();
            }
	    }

        // Code that runs every frame.
        public override void OnUpdate()
	    {
		
	    }

	    // Code that runs when exiting the state.
	    public override void OnExit()
	    {
            UIModalCharacterDialog dlg = UIModalManager.instance.ModalGetController<UIModalCharacterDialog>(
                modalRef.IsNone ? UIModalCharacterDialog.defaultModalRef : modalRef.Value);

            if(dlg != null) {
                dlg.actionCallback -= OnAction;
            }
	    }

        void OnAction(int choiceIndex) {
            if(choiceIndex != -1) {
                //save to variable
                if(!choiceOutput.IsNone) {
                    choiceOutput.Value = choiceIndex;
                }

                //save to scene state
                if(!choiceSceneStateOutput.IsNone) {
                    if(choiceSceneStateGlobal.Value) {
                        SceneState.instance.SetGlobalValue(choiceSceneStateOutput.Value, choiceIndex, choiceSceneStatePersist.Value);
                    }
                    else {
                        SceneState.instance.SetValue(choiceSceneStateOutput.Value, choiceIndex, choiceSceneStatePersist.Value);
                    }
                }
            }

            //close?
            if(closeOnAction.Value && UIModalManager.instance.ModalGetTop() == modalRef.Value) {
                UIModalManager.instance.ModalCloseTop();
            }

            //envoke event
            if(!FsmEvent.IsNullOrEmpty(actionEvent)) {
                Fsm.Event(actionEvent);
            }

            Finish();
        }
    }
}
