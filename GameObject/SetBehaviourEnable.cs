using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker;

[ActionCategory("Mate GameObject")]
[Tooltip("Enable/Disable given behaviour type from game object")]
public class SetBehaviourEnable : FsmStateAction {
    [RequiredField]
    [Tooltip("The GameObject that owns the Component.")]
    public FsmOwnerDefault gameObject;
    
    [RequiredField]
    [UIHint(UIHint.Behaviour)]
    [Tooltip("The name of the Component to destroy.")]
    public FsmString component;

    public FsmBool enable;

    private MonoBehaviour mComponent;

    public override void Reset()
    {
        mComponent = null;
        gameObject = null;
        component = null;
        enable = null;
    }
    
    public override void OnEnter()
    {
        DoIt(gameObject.OwnerOption == OwnerDefaultOption.UseOwner ? Owner : gameObject.GameObject.Value);
        
        Finish();
    }
    

    void DoIt(GameObject go)
    {
        mComponent = go.GetComponent(component.Value) as MonoBehaviour;
        
        if (mComponent == null)
        {
            LogError("No such behaviour: " + component.Value);
        }
        else
        {
            mComponent.enabled = enable.Value;
        }
    }
}
