using UnityEngine;

namespace HutongGames.PlayMaker.Actions.M8 {
    [Tooltip("Add a new type for pool.")]
    public class PoolAddType : PoolBase {
        [Tooltip("This will create a new Pool Controller if pool is not found.")]
        public FsmBool createIfNotFound;

        public FsmGameObject template;

        [Tooltip("Optional name for template. If None or Empty, use template.name.")]
        public FsmString templateName;

        [Tooltip("Number of spawns to allocate and cache upon adding type.")]
        public FsmInt startCapacity;
        [Tooltip("Capacity for the type.")]
        public FsmInt maxCapacity;

        [Tooltip("Where to put the instanced object under when spawned if no parent is specified in Spawn.")]
        public FsmGameObject defaultParent;

        public override void Reset() {
            base.Reset();

            createIfNotFound = true;

            template = null;

            startCapacity = 0;
            maxCapacity = 10;

            defaultParent = new FsmGameObject { UseVariable = true };
        }

        public override void OnEnter() {
            var poolCtrl = pool.GetPoolController(Fsm, createIfNotFound.Value);
            
            if(poolCtrl) {
                Transform defaultParentTrans = null;
                if(defaultParent.Value)
                    defaultParentTrans = defaultParent.Value.transform;

                if(templateName.IsNone || string.IsNullOrEmpty(templateName.Value))
                    poolCtrl.AddType(template.Value, startCapacity.Value, maxCapacity.Value, defaultParentTrans);
                else
                    poolCtrl.AddType(templateName.Value, template.Value, startCapacity.Value, maxCapacity.Value, defaultParentTrans);
            }
            else
                Debug.LogWarning("Unable to get pool.");

            Finish();
        }

        public override string ErrorCheck() {
            var errStr = "";

            if(pool != null) {
                switch(pool.from) {
                    case FsmPool.FromType.Owner:
                        if(Fsm.Owner == null)
                            errStr = "Owner is empty.";
                        break;
                    case FsmPool.FromType.GameObject:
                        if(pool.gameObject.IsNone || pool.gameObject.Value == null)
                            errStr = "GameObject is empty.";
                        break;
                    case FsmPool.FromType.Group:
                        if(pool.groupName.IsNone || string.IsNullOrEmpty(pool.groupName.Value))
                            errStr = "Group is empty.";
                        break;
                }
            }

            if(string.IsNullOrEmpty(errStr) && (template.IsNone || template.Value == null))
                errStr = "Template is empty.";

            return errStr;
        }
    }
}