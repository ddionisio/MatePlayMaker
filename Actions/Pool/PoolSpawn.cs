using UnityEngine;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [Tooltip("Spawn a game object from pool.")]
    public class PoolSpawn : PoolBase {        
        [Tooltip("The type from Pool to spawn. If using GameObject, make sure this matches from Pool.")]
        public FsmGameObjectName template;

        [Tooltip("Name of the spawned GameObject.")]
        public FsmString spawnName;

        [Tooltip("Spawn under this GameObject. If none, use Pool's preference.")]
        public FsmGameObject spawnToParent;

        [Tooltip("Spawn world position.")]
        public FsmVector3 spawnPosition;
        [Tooltip("Spawn world euler rotation.")]
        public FsmVector3 spawnRotation;
        
        [CompoundArray("Spawn Parameters", "Name", "Object")]
        public FsmString[] spawnParamNames;
        public FsmVar[] spawnParamObjects;

        [UIHint(UIHint.Variable)]
        public FsmGameObject spawnOutput;

        private GenericParams mSpawnParms = new GenericParams();

        public override void Reset() {
            base.Reset();

            template = new FsmGameObjectName { from = FsmGameObjectName.FromType.String };

            spawnName = new FsmString { UseVariable = true };
            spawnToParent = new FsmGameObject { UseVariable = true };
            spawnPosition = new FsmVector3 { UseVariable = true };
            spawnRotation = new FsmVector3 { UseVariable = true };

            spawnParamNames = new FsmString[0];
            spawnParamObjects = new FsmVar[0];

            spawnOutput = null;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            var poolCtrl = pool.GetPoolController(Fsm, false);
            if(poolCtrl) {
                string typeName = template != null ? template.GetName() : "";

                //setup name
                string toName;
                if(spawnName.IsNone)
                    toName = null;
                else
                    toName = spawnName.Value;

                //setup parent
                Transform toParent;
                if(spawnToParent.IsNone)
                    toParent = null;
                else
                    toParent = spawnToParent.Value.transform;

                //setup parameters
                for(int i = 0; i < spawnParamNames.Length; i++) {
                    var parmName = spawnParamNames[i].Value;
                    if(!string.IsNullOrEmpty(parmName))
                        mSpawnParms[parmName] = spawnParamObjects[i].GetValue();
                }

                //spawn
                var spawn = poolCtrl.Spawn(typeName, toName, toParent, mSpawnParms);

                if(spawn) {
                    var spawnTrans = spawn.transform;

                    if(!spawnPosition.IsNone)
                        spawnTrans.position = spawnPosition.Value;

                    if(!spawnRotation.IsNone)
                        spawnTrans.rotation = Quaternion.Euler(spawnRotation.Value);

                    if(!spawnOutput.IsNone)
                        spawnOutput.Value = spawn.gameObject;
                }
                else {
                    Debug.LogWarning(string.Format("Unable to spawn from pool: {0}, type: {1}", poolCtrl.name, typeName));
                }
            }
            else {
                Debug.LogWarning("Pool does not exists.");
            }

            Finish();
        }

        public override string ErrorCheck() {
            var errStr = base.ErrorCheck();
            if(string.IsNullOrEmpty(errStr)) {
                if(template != null) {
                    if(!template.IsValid())
                        errStr = "Template is empty.";
                }
            }

            return errStr;
        }
    }
}
