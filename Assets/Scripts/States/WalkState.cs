using UnityEngine;

public class WalkState : MonoBehaviour
{

    [SerializeField] private float walkSpeed;
    private BaseIA baseIA;

    private void Start()
    {
        baseIA = GetComponent<BaseIA>();
    }

    public void Enter()
    {
        // L�gica de inicializa��o do estado Walk
    }

    public void Execute()
    {
        // L�gica do estado Walk
        
    }

    public void Exit()
    {
        // L�gica de sa�da do estado Walk
    }
}
