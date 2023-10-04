using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseState : State
{
    public IdleState idleState;
    public AttackState attackState;
    public ReturnState returnState;

    GameObject player;

    BaseIA b;


    public override State RunCurrentState(){
        b.Move(player.transform.position);

        if(b.gridActive){
            if(b.collided){
                return attackState;
            }
            return this;
        }else{
            return returnState;
        }
    }

    public override void StartState(BaseIA b){
        this.b = b;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void ExitState(){
        
    }
}
