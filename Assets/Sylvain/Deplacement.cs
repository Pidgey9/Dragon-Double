using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour
{
    public GameObject Players;
    public Rigidbody2D rb;
    public Vector3 Move;
    public float Speed = 20f;
    public float Hx;
    public float Vy;

    
   

    // Update is called once per frame
    void Update()
    {
        Hx = Input.GetAxis("Horizontal");
        Vy = Input.GetAxis("Vertical");
        Move = new Vector3(Hx, Vy, 0);
        
    }
    void FixedUpdate()
    {
        rb.velocity = Move * Speed;  

    }
}
