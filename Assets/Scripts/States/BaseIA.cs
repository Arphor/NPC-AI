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
        startPosition = gameObject.transform.position;

        //Get best path towards player
        //Essa parte ta funcionando
        grid = GameObject.Find("Grid").GetComponent<GridManager>();
        GameObject p = GameObject.Find("Circle");
        Debug.Log(new Vector2Int(Mathf.FloorToInt(p.transform.position.x), Mathf.FloorToInt(p.transform.position.y)));
        path = grid.makePath(new Vector2Int(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y)), new Vector2Int(Mathf.FloorToInt(p.transform.position.x), Mathf.FloorToInt(p.transform.position.y)));

        ReferenceLine(this.transform.position, p.transform.position);
        //Esse while foi só pra desenhar o caminho que ele achou
        //E tentando que ele detectasse partes onde o objeto ia colidir com paredes devido as quinas, mas não consegui acertar aqui de jeito nenhum
        //Por algum motivo ele ta detectando a colisão depois da quina, e não durante
        Spot pre = new Spot(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y), 0);
        while(path.Count > 0){
            Spot next = path.Dequeue();

            Vector3 origin = new Vector3(pre.X+0.5f, pre.Y+0.5f, 0);
            Vector3 target = new Vector3(next.X+0.5f, next.Y+0.5f, 0);

            if(origin.x != target.x && origin.y != target.y){
                Vector3 origin_r = new Vector3(origin.x+0.5f, origin.y-0.5f, 0);
                Vector3 origin_l = new Vector3(origin.x-0.5f, origin.y+0.5f, 0);

                Vector3 target_r = new Vector3(target.x+0.5f, target.y-0.5f, 0);
                Vector3 target_l = new Vector3(target.x-0.5f, target.y+0.5f, 0);

                ReferenceLine(origin_r, target_r);
                ReferenceLine(origin_l, target_l);
                ReferenceLine(origin, target);
            }else{
                ReferenceLine(origin, target);
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