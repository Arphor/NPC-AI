using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnState : State
{
    public chaseState chaseState;
    public IdleState idleState;

    Vector3 target;

    BaseIA b;

    public override void StartState(BaseIA b){
        this.b = b;

        target = b.startPosition;
    }

    public override void ExitState(){
        
    }

    public override State RunCurrentState(){
        if(b.gridActive){
            return chaseState;
        }else{
            if(b.transform.position != b.startPosition){
                b.Move(b.startPosition);

                return this;
            }else{
                return idleState;
            }
        }
    }
}
