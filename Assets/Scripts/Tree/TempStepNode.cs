using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TempStepNode : Node
{
    Transform npc;
    BaseIA ia;
    float walkSpeed;

    public TempStepNode(Transform npc, BaseIA ia, float walkSpeed){
        this.npc = npc;
        this.ia = ia;
        this.walkSpeed = walkSpeed;
    }

    public override NodeState Evaluate(){

        List<Spot> spots = ia.path;

        if(spots.Count == 0){
            return NodeState.FAILURE;
        }

        if(!(new Vector2(npc.position.x, npc.position.y) == new Vector2(spots.First().X + 0.5f, spots.First().Y + 0.5f))){
            npc.position = Vector2.MoveTowards(npc.position, new Vector2(spots[0].X + 0.5f, spots[0].Y + 0.5f), walkSpeed * Time.deltaTime);
        }else{
            spots.RemoveAt(0);
        }

        return NodeState.SUCCESS;

    }
}
