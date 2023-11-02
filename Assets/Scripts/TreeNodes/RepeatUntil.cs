using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatUntil : Node
{
    protected Node node;
    protected NodeState targetState;

    public RepeatUntil(Node node, NodeState state){
        this.node = node;
        this.targetState = state;
    }

    public override NodeState Evaluate(){

        if(node.Evaluate() != targetState){
            _nodeState = NodeState.RUNNING;
        }else{
            _nodeState = NodeState.SUCCESS;
        }


        return _nodeState;
    }
}
