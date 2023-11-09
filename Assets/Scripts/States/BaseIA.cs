using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class BaseIA : MonoBehaviour
{
    [SerializeField]
    protected float respawnTime = 2;    

    [SerializeField]
    protected float runSpeed = 5f;
    [SerializeField]
    protected float walkSpeed = 2.5f;

    protected Vector3 targetPosition;

    public Vector3 startPosition;

    public List<Grid> grids = new List<Grid>();

    public bool collided = false;

    GameObject currentGrid;

    public State currentState;

    private void RunStateMachine(){
        currentState.RunCurrentState();
    }

    public void SwitchStates(State nextState){
        if (nextState != null)
        {
            currentState.ExitState();
            currentState = nextState;
            currentState.StartState(this);
        }
        else
        {
            Debug.LogError("BASEIA 'NextState' NULL");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //currentGrid = transform.parent.gameObject;
        startPosition = gameObject.transform.position;

        //currentState.StartState(this);
    }

    // Update is called once per frame
    void Update()
    {
        //gridActive = currentGrid.GetComponent<Grid>().active;
        

        //RunStateMachine();
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

    public void addGrid(Grid g){
        grids.Add(g);
    }

    public void removeGrid(Grid g){
        grids.Remove(g);
    }

    public void setTargetPosition(Vector3 targetPosition){
        this.targetPosition = targetPosition;
    }
}