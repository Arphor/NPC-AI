using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtStartPoint : Node
{
    Transform currentPosition;
    Vector3 startPosition;

    public AtStartPoint(Transform currentPosition, Vector3 startPosition){
        this.currentPosition = currentPosition;
        this.startPosition = startPosition;
    }

    public override NodeState Evaluate(){
        Debug.Log((currentPosition.position == startPosition) + " " + currentPosition.position + " " + startPosition);
        return currentPosition.position == startPosition ? NodeState.SUCCESS : NodeState.FAILURE;

    }

}
