using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePathNode : Node
{
    GridManager grid;
    BaseIA ia;

    public MakePathNode(GridManager grid, BaseIA ia){
        this.grid = grid;
        this.ia = ia;
    }

    public override NodeState Evaluate(){
        Vector2Int origin = new Vector2Int(Mathf.FloorToInt(ia.gameObject.transform.position.x), Mathf.FloorToInt(ia.gameObject.transform.position.y));
        Vector2Int target = new Vector2Int(Mathf.FloorToInt(ia.targetPosition.x), Mathf.FloorToInt(ia.targetPosition.y));

        List<Spot> path = grid.makePath(origin, target);

        ia.setPath(path);
        ia.walkingTo = ia.targetPosition;

        return NodeState.SUCCESS;

    }
}
