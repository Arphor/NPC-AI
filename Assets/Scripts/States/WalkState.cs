using UnityEngine;

public class WalkState : BaseIA
{
    public WalkState()
    {
        Debug.Log("WALK INITIALIZED");
    }

    public void Enter()
    {
        // L�gica de inicializa��o do estado Walk
    }

    public void Execute()
    {
        // L�gica do estado Walk
        Move(walkSpeed);
    }

    public void Exit()
    {
        // L�gica de sa�da do estado Walk
    }
}
