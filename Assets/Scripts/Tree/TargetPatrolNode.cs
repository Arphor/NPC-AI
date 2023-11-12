using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPatrolNode : Node
{

    public List<Grid> grids = new List<Grid>();
    BaseIA ia;

    public TargetPatrolNode(List<Grid> grids, BaseIA ia){
        this.grids = grids;
        this.ia = ia;
    }

    public override NodeState Evaluate(){

        Vector3 point = grids[0].randomPoint();
        while(Physics2D.OverlapPoint(new Vector2(point.x, point.y), LayerMask.GetMask("Walls"))){
            point = grids[0].randomPoint();
        }

        ia.setTargetPosition(point);

        return NodeState.SUCCESS;

    }

}
