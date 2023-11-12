using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class Grid : MonoBehaviour
{
    public bool active = false;

    Vector3 tileMapCenter;
    Vector3 tileMapExtents;

    private void Start(){
        TilemapCollider2D tileMap = gameObject.GetComponent<TilemapCollider2D>();
        Bounds bounds = tileMap.bounds;

        tileMapCenter = bounds.center;
        tileMapExtents = bounds.extents;     
        
    }

    public Vector3 randomPoint(){
        System.Random r = new System.Random();
        int x = r.Next(Mathf.FloorToInt(tileMapCenter.x -tileMapExtents.x), Mathf.FloorToInt(tileMapCenter.x +tileMapExtents.x));
        int y = r.Next( Mathf.FloorToInt(tileMapCenter.y-tileMapExtents.y), Mathf.FloorToInt(tileMapCenter.y+tileMapExtents.y));

        return new Vector3(x+0.5f, y+0.5f, 0);
    }
    

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            this.active = true;
        }

        if(other.gameObject.tag == "Enemy"){
            other.GetComponent<BaseIA>().addGrid(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            this.active = false;
        }
        if(other.gameObject.tag == "Enemy"){
            other.GetComponent<BaseIA>().removeGrid(this);
        }
    }
}
