using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] public int health = 100;
    public static float moveforce = 10f;

    Rigidbody2D rb;

    Vector3 mov = Vector3.zero;

    private void Start() {
        rb=GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        mov.x = Input.GetAxis("Horizontal");
        mov.y = Input.GetAxis("Vertical");

        mov.Normalize();

        rb.velocity = mov *moveforce;
        //heal_display.text="Health: " + health.ToString();
    }

    public void addhealth(int x){
        health += x;

        if(health > 100){
            health = 100;
        }
    }

    public void ApplyDamage(int x){
        health -= x;

        if(health < 0){
            health = 0;
        }
    }
}
