using UnityEngine;

public class IdleState : BaseIA
{
    private float idleTime;

    public IdleState()
    {
        Debug.Log("IDLE INITIALIZED");
    }

    public void Enter()
    {
        idleTime = Time.time;
    }

    public void Execute()
    {
        // L�gica do estado Idle
        if (Time.time > idleTime + waitTime)
        {
            TransitionToState(State.WALK);
        }
    }

    public void Exit()
    {
        // L�gica de sa�da do estado Idle
    }
}
