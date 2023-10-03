using UnityEngine;

public class RunState : BaseIA
{
    public RunState()
    {
        Debug.Log("RUN INITIALIZED");
    }

    public void Enter()
    {
        // L�gica de inicializa��o do estado Run
    }

    public void Execute()
    {
        Move(runSpeed);
    }

    public void Exit()
    {
        // L�gica de sa�da do estado Run
    }
}
