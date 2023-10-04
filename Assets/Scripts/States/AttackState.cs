using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public IdleState idleState;
    public chaseState chaseState;

    GameObject player;

    BaseIA b;

    public override State RunCurrentState(){
        StartCoroutine(DelayAction());
        b.collided = false;



        if(!b.collided){
            return chaseState;
        }
        return this;

    }

    IEnumerator DelayAction()
    {
        player.GetComponent<Player>().ApplyDamage(10);

        yield return new WaitForSeconds(2);
    
    }

    public override void StartState(BaseIA b){
        this.b = b;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void ExitState(){
        
    }
}
