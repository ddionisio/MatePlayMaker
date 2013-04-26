using UnityEngine;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Mate Scene")]
	public class SceneValueSet : FsmStateAction
	{
        [RequiredField]
        public FsmString name;

        public bool global;

        [RequiredField]
        public FsmInt val;

        public FsmBool persistent;
				
		public override void Reset()
		{
            name = null;
            global = false;
            val = null;
            persistent = false;
		}
		
		public override void OnEnter ()
		{
            if(SceneState.instance != null) {
                if(global)
                    SceneState.instance.SetGlobalValue(name.Value, val.Value, persistent.Value);
                else
                    SceneState.instance.SetValue(name.Value, val.Value, persistent.Value);
            }

            Finish();
		}
	}
}
