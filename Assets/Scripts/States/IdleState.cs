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
        // Lógica do estado Idle
        if (Time.time > idleTime + waitTime)
        {
            TransitionToState(State.WALK);
        }
    }

    public void Exit()
    {
        // Lógica de saída do estado Idle
    }
}
