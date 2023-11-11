using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System;

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

    GridManager grid;

    public State currentState;

    Queue<Spot> path = new Queue<Spot>();

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

        grid = GameObject.Find("Grid").GetComponent<GridManager>();
        GameObject p = GameObject.Find("Circle");
        Debug.Log(new Vector2Int(Mathf.FloorToInt(p.transform.position.x), Mathf.FloorToInt(p.transform.position.y)));
        path = grid.makePath(new Vector2Int(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y)), new Vector2Int(Mathf.FloorToInt(p.transform.position.x), Mathf.FloorToInt(p.transform.position.y)));
        //currentState.StartState(this);

        Spot pre = new Spot(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y), 0);
        while(path.Count > 0){
            Spot next = path.Dequeue();

            Vector3 origin = new Vector3(pre.X+0.5f, pre.Y+0.5f, 0);
            Vector3 target = new Vector3(next.X+0.5f, next.Y+0.5f, 0);

            Vector3 directionTarget = (origin - target).normalized;
            float distanceToTarget = Vector3.Distance(origin, target);
            RaycastHit hit;
            //Physics.SphereCast(origin, 2, directionTarget, out hit, distanceToTarget, LayerMask.GetMask("Walls"));
            //Debug.Log(hit);
            if(Physics2D.BoxCast(origin, new Vector2(0.25f, 0.25f), Vector2.Angle(new Vector2(origin.x, origin.y), new Vector2(origin.x, origin.y)), directionTarget, distanceToTarget, LayerMask.GetMask("Walls"), 0, 0)){
                Debug.Log(Physics2D.BoxCast(origin, new Vector2(0.5f, 0.5f), Vector2.Angle(new Vector2(origin.x, origin.y), new Vector2(origin.x, origin.y)), directionTarget, distanceToTarget, LayerMask.GetMask("Walls")).collider.gameObject.name);
                Debug.DrawLine(origin, target, Color.red, 2000);
            }else{
                Debug.DrawLine(origin, target, Color.green, 2000);
            }

            pre = next;
        }
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
        if(!grids.Contains(g)){
            grids.Add(g);
        }
    }

    public void removeGrid(Grid g){
        grids.Remove(g);
    }

    public void setTargetPosition(Vector3 targetPosition){
        this.targetPosition = targetPosition;
    }
}