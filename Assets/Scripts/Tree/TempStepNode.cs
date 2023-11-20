using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

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


        try
        {

            if(ia.path == null)
            {
                return NodeState.FAILURE;
            }


            List<Spot> spots = ia.path;

            if (!(new Vector2(npc.position.x, npc.position.y) == new Vector2(spots.First().X + 0.5f, spots.First().Y + 0.5f)))
            {
                npc.position = Vector2.MoveTowards(npc.position, new Vector2(spots[0].X + 0.5f, spots[0].Y + 0.5f), walkSpeed * Time.deltaTime);
            }
            else
            {
                spots.RemoveAt(0);
            }

            return NodeState.SUCCESS;

        }
        catch (Exception e)
        {

            Debug.LogError(e + " - TemStepNode.cs Line 41");
            return NodeState.FAILURE;
            throw;
        }

        

    }
}
