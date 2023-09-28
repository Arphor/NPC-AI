using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("oi");
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<Player>().addhealth(15);

            gameObject.SetActive(false);
        }
    }
}
