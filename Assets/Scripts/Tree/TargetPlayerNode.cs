using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayerNode : Node
{
    BaseIA ia;

    public TargetPlayerNode(BaseIA ia){
        this.ia = ia;
    }

    public override NodeState Evaluate(){
        ia.setTargetPosition(GameObject.FindWithTag("Player").transform.position);

        return NodeState.SUCCESS;

    }
}
