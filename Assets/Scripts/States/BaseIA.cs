using UnityEngine;
using UnityEngine.AI;

public class BaseIA : MonoBehaviour
{
    [SerializeField]
    protected float waitTime = 2;    

    [SerializeField]
    protected float runSpeed = 5f;
    [SerializeField]
    protected float walkSpeed = 2.5f;

    [SerializeField]
    private PathPosition[] dots;
    private int currentDot;

    public enum State
    {
        IDLE,
        WALK,
        RUNNING
    }

    private State currentState;
    private IdleState idleState;
    private WalkState walkState;
    private RunState runState;

    // Start is called before the first frame update
    void Start()
    {
        currentDot = 0;

        currentState = State.IDLE;
        idleState = gameObject.AddComponent<IdleState>();
        walkState = gameObject.AddComponent<WalkState>();
        runState = gameObject.AddComponent<RunState>();

        // Inicializa o estado atual
        TransitionToState(currentState);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.IDLE:
                idleState.Execute();
                break;
            case State.WALK:
                walkState.Execute();
                break;
            case State.RUNNING:
                runState.Execute();
                break;
            default:
                idleState.Execute();
                break;
        }
    }

    protected void TransitionToState(State nextState)
    {
        switch (currentState)
        {
            case State.IDLE:
                idleState.Exit();
                break;
            case State.WALK:
                walkState.Exit();
                break;
            case State.RUNNING:
                runState.Exit();
                break;
        }

        currentState = nextState;

        switch (nextState)
        {
            case State.IDLE:
                idleState.Enter();
                break;
            case State.WALK:
                walkState.Enter();
                break;
            case State.RUNNING:
                runState.Enter();
                break;
            default:
                idleState.Enter();
                break;
        }
    }

    protected void Move(float speed)
    {
        this.transform.position = Vector2.MoveTowards(transform.position, dots[currentDot].position, speed * Time.deltaTime);

        NextPosition();
    }

    private void NextPosition()
    {  
        if( this.transform.position == dots[currentDot].position)
        {
            currentDot += 1;

            if (currentDot >= dots.Length)
            {
                currentDot = 0;
            }

            if (dots[currentDot].IsIdlePosition())
            {
                TransitionToState(State.IDLE);
            }
            else
            {
                if (currentDot % 2 != 0)
                {
                    TransitionToState(State.WALK);
                }
                else
                {
                    TransitionToState(State.RUNNING);
                }
            }
        }        
    }
}