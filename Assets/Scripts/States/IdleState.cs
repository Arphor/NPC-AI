using UnityEngine;

public class IdleState : State
{
    public chaseState chaseState;

    public override State RunCurrentState(BaseIA b){
        if(b.gridActive){
            return chaseState;
        }else{
            if(b.transform.position != b.startPosition){
                b.Move(b.startPosition);
            }
            return this;
        }
    }

}
