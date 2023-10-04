using UnityEngine;

public class RunState : MonoBehaviour
{
    [SerializeField] private float runSpeed;
    private BaseIA baseIA;

    private void Start()
    {
        baseIA = GetComponent<BaseIA>();
    }

    public void Enter()
    {
        // L�gica de inicializa��o do estado Run
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        // L�gica de sa�da do estado Run
    }
}
