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
    void Awake()
    {
        this.CreateGrid();

        astar = new Astar(spots, bounds.size.x, bounds.size.y);
    }

    void CreateGrid(){
        walls.CompressBounds();
        bounds = walls.cellBounds;

        spots = new Vector3Int[bounds.size.x, bounds.size.y];

        //Le toda a grid
        for (int x = bounds.xMin, i = 0; i < (bounds.size.x); x++, i++){
            for (int y = bounds.yMin, j = 0; j < (bounds.size.y); y++, j++){
                //Verifica se tem colisor "se é wall" ou não
                if (walls.HasTile(new Vector3Int(x, y, 0)))
                {
                    spots[i, j] = new Vector3Int(x, y, 1);
                }
                else
                {
                    spots[i, j] = new Vector3Int(x, y, 0);
                }
            }
        }
    }

    public List<Spot> makePath(Vector2Int start, Vector2Int end){

        return astar.CreatePath(spots, end, start, 1000);
    }

}
