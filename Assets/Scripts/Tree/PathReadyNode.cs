using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PathReadyNode : Node
{

    public List<Spot> spots = new List<Spot>();
    BaseIA ia;

    public PathReadyNode(BaseIA ia){
        this.ia = ia;
    }

    public override NodeState Evaluate(){

        if(ia.path.Count > 0){
            return NodeState.SUCCESS;
        }

        return NodeState.FAILURE;

    }
}