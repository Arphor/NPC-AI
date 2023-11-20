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

    public Vector3 targetPosition = Vector3.zero;
    public Vector3 startPosition = Vector3.zero;
    public Vector3 walkingTo = Vector3.zero;

    public List<Grid> grids = new List<Grid>();

    public bool collided = false;

    GridManager grid;

    public State currentState;

    public List<Spot> path = new List<Spot>();

    Node TreeRoot;

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

    void ReferenceLine(Vector3 start, Vector3 end){
        Vector3 directionTarget = (start - end).normalized;

        float distanceToTarget = Vector3.Distance(start, end);
        //Physics2D.Raycast(start, directionTarget, distanceToTarget, LayerMask.GetMask("Walls"))
        if(Physics2D.Linecast(start, end, LayerMask.GetMask("Walls"))){
            Debug.DrawLine(start, end, Color.red, 2000);
        }else{
            Debug.DrawLine(start, end, Color.green, 2000);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(Mathf.FloorToInt(gameObject.transform.position.x) + 0.5f, Mathf.FloorToInt(gameObject.transform.position.y) + 0.5f, 0);
        gameObject.transform.position = pos;

        this.startPosition = pos;
        this.walkingTo = pos;

        //Get best path towards player
        //Essa parte ta funcionando
        grid = GameObject.Find("Grid").GetComponent<GridManager>();

        this.ConstructTree();
    

    }

    void ConstructTree(){

        //Leafs
        IsIdleNode isIdle = new IsIdleNode(this);
        Inverter InverterIsIdle = new Inverter(isIdle);

        LookNode seePlayer = new LookNode(this.transform, 10);
        TargetPlayerNode targetPlayer = new TargetPlayerNode(this);

        TargetPatrolNode targetPatrol = new TargetPatrolNode(this.grids, this);

        AtStartPoint atStartPosition = new AtStartPoint(this.transform, startPosition);
        Inverter InverterAtStart = new Inverter(atStartPosition);
        TargetStart targetStart = new TargetStart(this, startPosition);

        PathReadyNode pathReady = new PathReadyNode(this);

        MakePathNode makePath = new MakePathNode(grid, this);
        
        TempStepNode step = new TempStepNode(this.transform, this, walkSpeed);


        //Parent Nodes
        Sequence Chasing = new Sequence(new List<Node> {seePlayer, targetPlayer});
        Selection Act = new Selection(new List<Node> {Chasing, targetPatrol});

        Sequence Active = new Sequence(new List<Node> {InverterIsIdle, Act});


        Sequence Return = new Sequence(new List<Node> {InverterAtStart, targetStart});

        Selection FindMovement = new Selection(new List<Node> {Active, Return});


        Selection Pathing = new Selection(new List<Node> {pathReady, makePath});

        Sequence Move = new Sequence(new List<Node> {Pathing, step});

        TreeRoot = new Sequence(new List<Node> {FindMovement, Move});

    }

    // Update is called once per frame
    void Update()
    {
        TreeRoot.Evaluate();
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

    public void setPath(List<Spot> path){
        this.path = path;
    }
}