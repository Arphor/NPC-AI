using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookNode : Node
{
    Transform currentPosition;
    float visionRange;
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public LookNode(Transform currentPosition, float visionRange, LayerMask targetMask, LayerMask obstructionMask){
        this.currentPosition = currentPosition;
        this.visionRange = visionRange;
        this.targetMask = LayerMask.GetMask("Player");
        this.obstructionMask = LayerMask.GetMask("Walls");
    }

    public override NodeState Evaluate(){
        Collider[] rangeChecks = Physics.OverlapSphere(currentPosition.position, visionRange, targetMask);

        if(rangeChecks.Length != 0){
            Transform target = rangeChecks[0].transform;
            Vector3 directionTarget = (target.position - currentPosition.position).normalized;

            float distanceToTarget = Vector3.Distance(currentPosition.position, target.position);

            if(!Physics.Raycast(currentPosition.position, directionTarget, distanceToTarget, obstructionMask)){
                return NodeState.SUCCESS;
            }
        }

        return NodeState.FAILURE;
    }

}
