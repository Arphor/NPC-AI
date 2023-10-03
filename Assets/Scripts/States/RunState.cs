using UnityEngine;

public class RunState : BaseIA
{
    public RunState()
    {
        Debug.Log("RUN INITIALIZED");
    }

    public void Enter()
    {
        // Lógica de inicialização do estado Run
    }

    public void Execute()
    {
        Move(runSpeed);
    }

    public void Exit()
    {
        // Lógica de saída do estado Run
    }
}
