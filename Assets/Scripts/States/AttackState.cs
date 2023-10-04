using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public IdleState idleState;
    public chaseState chaseState;

    public override State RunCurrentState(BaseIA b){
        Debug.Log("Attack");
        StartCoroutine(DelayAction());
        b.collided = false;


        if(b.gridActive){
            if(!b.collided){
                return chaseState;
            }
            return this;
        }else{
            return idleState;
        }
    }

    IEnumerator DelayAction()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Player>().ApplyDamage(10);

        yield return new WaitForSeconds(2);


    
    
    }
}
