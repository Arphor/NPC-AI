using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseState : State
{
    public IdleState idleState;
    public AttackState attackState;


    public override State RunCurrentState(BaseIA b){
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        b.Move(player.transform.position);

        if(b.gridActive){
            if(b.collided){
                return attackState;
            }
            return this;
        }else{
            return idleState;
        }
    }
}
