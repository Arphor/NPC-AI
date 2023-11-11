using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class GridManager : MonoBehaviour
{
    public Tilemap walls;

    private BoundsInt bounds;

    public Vector3Int[,] spots;

    Astar astar;
    // Start is called before the first frame update
    void Start()
    {
        this.CreateGrid();

        astar = new Astar(spots, bounds.size.x, bounds.size.y);
    }

    void CreateGrid(){
        walls.CompressBounds();
        bounds = walls.cellBounds;

        Vector3 tileMapCenter = bounds.position;
        Vector3 tileMapExtents = bounds.size;

        Vector3 topbound = new Vector3(tileMapCenter.x, tileMapCenter.y + tileMapExtents.y, tileMapCenter.z);

        Vector3 rightbound = new Vector3(tileMapCenter.x + tileMapExtents.x, tileMapCenter.y, tileMapCenter.z);

        spots = new Vector3Int[bounds.size.x, bounds.size.y];

        for (int x = bounds.xMin, i = 0; i < (bounds.size.x); x++, i++){
            for (int y = bounds.yMin, j = 0; j < (bounds.size.y); y++, j++){
                if (walls.HasTile(new Vector3Int(x, y, 0))){
                    spots[i, j] = new Vector3Int(x, y, 1);
                }else{
                    spots[i, j] = new Vector3Int(x, y, 0);
                }
            }
        }
    }

    public Queue<Spot> makePath(Vector2Int start, Vector2Int end){

        Queue<Spot> queue = new Queue<Spot>(astar.CreatePath(spots, end, start, 1000));
        return queue;
    }

}