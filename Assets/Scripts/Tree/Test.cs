using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TilemapCollider2D tilemapCollider = gameObject.GetComponent<TilemapCollider2D>();

        Vector3 tileMapCenter = tilemapCollider.bounds.center;
        Vector3 tileMapExtents = tilemapCollider.bounds.extents;

        Vector3 leftbound = new Vector3(tileMapCenter.x, tileMapCenter.y + tileMapExtents.y, tileMapCenter.z);
        Vector3 rightbound = new Vector3(tileMapCenter.x, tileMapCenter.y - tileMapExtents.y, tileMapCenter.z);

        Vector3 topbound = new Vector3(tileMapCenter.x + tileMapExtents.x, tileMapCenter.y, tileMapCenter.z);
        Vector3 bottombound = new Vector3(tileMapCenter.x - tileMapExtents.x, tileMapCenter.y, tileMapCenter.z);

        Debug.DrawLine(topbound, bottombound, Color.red, 20);
        Debug.DrawLine(leftbound, rightbound, Color.red, 20);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
