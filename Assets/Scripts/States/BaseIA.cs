using UnityEngine;
using UnityEngine.AI;

public class BaseIA : MonoBehaviour
{
    [SerializeField]
    protected float respawnTime = 2;    

    [SerializeField]
    protected float runSpeed = 5f;
    [SerializeField]
    protected float walkSpeed = 2.5f;

    public Vector3 startPosition;

    public bool gridActive = false;

    public bool collided = false;


    GameObject currentGrid;

    public State currentState;

    private void RunStateMachine(){
        State nextState = currentState?.RunCurrentState(this);

        if (nextState != null){
            SwitchStates(nextState);
        }
    }

    private void SwitchStates(State nextState){
        currentState = nextState;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentGrid = transform.parent.gameObject;
        startPosition = gameObject.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        gridActive = currentGrid.GetComponent<Grid>().active;
        

        RunStateMachine();
    }

    public void Move(Vector3 target)
    {
        this.transform.position = Vector2.MoveTowards(transform.position, target, walkSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.gameObject.CompareTag("Player")){
            collided = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision){

        if(collision.collider.gameObject.CompareTag("Player")){
            collided = false;
        }
    }
}