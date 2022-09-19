using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Vector2 move;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //transform.position += new Vector3(h * speed, v * speed, 0);
        move = new Vector2(h, v);
    }
    private void FixedUpdate()
    {
        rb.velocity = move * speed;
    }
}
