using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnState : State
{
    public ChaseState chaseState;
    public IdleState idleState;

    BaseIA baseIA;

    public override void StartState(BaseIA baseIA)
    {
        this.baseIA = baseIA;
    }

    public override void ExitState(){  }

    public override void RunCurrentState()
    {
        //if(baseIA.gridActive)
        //{
          //  baseIA.SwitchStates(chaseState);
        //}
        //else
        //{
          //  if(baseIA.transform.position != baseIA.startPosition)
           // {
           //     baseIA.Move(baseIA.startPosition);
            //}
           // else
            //{
             //   baseIA.SwitchStates(idleState);
           // }
       // }
    }
}
