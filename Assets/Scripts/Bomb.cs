using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] int radius;
    [SerializeField] int damage;
    private Vector3 location;

    private void Start() {
        location = gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){

            Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(location, radius);
            foreach (Collider2D col in objectsInRange)
            {

                if (col.gameObject.tag == "Enemy")
                {
                    Destroy(col.gameObject);
                }
            }

            gameObject.SetActive(false);
        }
    }
}
