using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetStart : Node
{
    BaseIA ia;
    Vector3 startPosition;

    public TargetStart(BaseIA ia, Vector3 startPosition){
        this.ia = ia;
        this.startPosition = startPosition;
    }

    public override NodeState Evaluate(){
        ia.setTargetPosition(startPosition);

        return NodeState.SUCCESS;

    }
}
