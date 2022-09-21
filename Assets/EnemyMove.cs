using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public Transform playerTransform;
    Vector2 dir;
    public Animator animator;
    public Boal isJumping;
    public Boal isPunching;
    public Boal isDamage;
    public Boal isUp;
    public Pos pos;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping.value = isDamage.value = isPunching.value = isUp.value = false;
        pos.value = Vector3.zero;
    }
    private void Update()
    {
        dir = (playerTransform.position - transform.position).normalized;
        // animators
        if (dir.x != 0 && dir.y != 0) animator.SetBool("Moving", true);
        else animator.SetBool("Moving", false);
        if (dir.x < 0) animator.SetFloat("playerDirection", 1);
        else animator.SetFloat("playerDirection", 0);
        //if (Random.value > 0.998) animator.SetTrigger("Punch");
        //if (Random.value < 0.01) animator.SetTrigger("Jump");
    }
    private void FixedUpdate()
    {
        rb.velocity = dir * speed;
        if (isDamage.value || isJumping.value || isPunching.value) rb.velocity = Vector2.zero;
        if (isJumping.value)
        {
            rb.AddForce(Vector2.up * 100);
            if (transform.position.y > pos.value.y + 1) animator.SetTrigger("JumpUp");
            if (isUp.value) rb.AddForce(Vector2.down * 200);
            if (transform.position.y < pos.value.y)
            {
                animator.SetTrigger("JumpDone");
            }

        }
    }
}
