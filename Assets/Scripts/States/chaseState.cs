using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public IdleState idleState;
    public AttackState attackState;
    public ReturnState returnState;

    GameObject player;
    BaseIA baseIA;

    public override void RunCurrentState()
    {
        if(player)
        {
            baseIA.Move(player.transform.position);
        }
        else
        {
            baseIA.SwitchStates(returnState);
            Debug.Log("GameOver");
        }

        //if(baseIA.gridActive)
        //{
           // if(baseIA.collided)
            //{
             //   baseIA.SwitchStates(attackState);
            //}
        //}
        //else
        //{
           // baseIA.SwitchStates(returnState);
       // }
    }

    public override void StartState(BaseIA baseIA)
    {
        this.baseIA = baseIA;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void ExitState(){   }
}
