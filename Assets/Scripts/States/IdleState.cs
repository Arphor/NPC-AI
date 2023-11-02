using UnityEngine;

public class IdleState : State
{
    public ChaseState chaseState;

    BaseIA baseIA;

    public override void StartState(BaseIA baseIA)
    {
        this.baseIA = baseIA;
    }

    public override void ExitState(){   }

    public override void RunCurrentState(){
        //if(baseIA.gridActive)
        //{
           // baseIA.SwitchStates(chaseState);
        //}
    }
}
