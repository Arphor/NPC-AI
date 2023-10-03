using UnityEngine;

public class WalkState : BaseIA
{
    public WalkState()
    {
        Debug.Log("WALK INITIALIZED");
    }

    public void Enter()
    {
        // Lógica de inicialização do estado Walk
    }

    public void Execute()
    {
        // Lógica do estado Walk
        Move(walkSpeed);
    }

    public void Exit()
    {
        // Lógica de saída do estado Walk
    }
}
