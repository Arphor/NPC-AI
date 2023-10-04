using UnityEngine;

public class IdleState : State
{
    public chaseState chaseState;

    BaseIA b;

    public override void StartState(BaseIA b){
        this.b = b;
    }

    public override void ExitState(){

    }

    public override State RunCurrentState(){
        if(b.gridActive){
            return chaseState;
        }else{
            return this;
        }
    }


}
