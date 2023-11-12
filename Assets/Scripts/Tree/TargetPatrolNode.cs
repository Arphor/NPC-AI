using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TargetPatrolNode : Node
{

    public List<Grid> grids = new List<Grid>();
    BaseIA ia;
    Vector3 lastPatrol = Vector3.zero;

    public TargetPatrolNode(List<Grid> grids, BaseIA ia){
        this.grids = grids;
        this.ia = ia;
    }

    public override NodeState Evaluate(){

        if(lastPatrol != Vector3.zero){
            if(lastPatrol == ia.targetPosition && ia.path.Count > 0){
                return NodeState.SUCCESS;
            }
        }

        Vector3 point = ia.grids[0].randomPoint();
        while(Physics2D.OverlapPoint(new Vector2(point.x, point.y), LayerMask.GetMask("Walls"))){
            point = ia.grids[0].randomPoint();
        }

        ia.setTargetPosition(point);
        lastPatrol = point;

        return NodeState.SUCCESS;

    }

}
