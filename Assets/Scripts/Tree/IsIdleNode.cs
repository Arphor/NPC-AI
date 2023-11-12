using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsIdleNode : Node
{
    BaseIA ia;

    public IsIdleNode(BaseIA ia){
        this.ia = ia;
    }

    public override NodeState Evaluate(){
        foreach(var g in ia.grids){
            if(g.active){
                Debug.Log("Active");
                return NodeState.FAILURE;
            }
        }
        Debug.Log("Idle");
        return NodeState.SUCCESS;
    }

}
