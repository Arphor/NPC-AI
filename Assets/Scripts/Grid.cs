using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public bool active = false;

    

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
