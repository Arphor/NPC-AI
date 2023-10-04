using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public IdleState idleState;
    public ChaseState chaseState;

    GameObject player;

    BaseIA baseIA;

    public override void RunCurrentState(){
        StartCoroutine(DelayAction());
        baseIA.collided = false;

        if(!baseIA.collided){
            baseIA.SwitchStates(chaseState);
        }

    }

    IEnumerator DelayAction()
    {
        player.GetComponent<Player>().ApplyDamage(10);

        yield return new WaitForSeconds(2);
    
    }

    public override void StartState(BaseIA baseIA)
    {
        this.baseIA = baseIA;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void ExitState(){
        
    }
}
