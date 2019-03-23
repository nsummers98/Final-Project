using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int playerDamage = 34;
    public float monsterSpeed = 3f;
    public LayerMask BlockingLayer;

    private BoxCollider2D bc2D;
    private Rigidbody2D rb2D;

    private Transform target;
    private bool skipMove;

    void Start()
    {
        bc2D = gameObject.GetComponent<BoxCollider2D>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        MoveMonster(); 
    }


    public void MoveMonster()
    {
        int xDir = 0;
        int yDir = 0;

        if (Mathf.Abs(target.position.y - transform.position.y) < 0.8 && Mathf.Abs(target.position.x - transform.position.x) < 0.8)
            return;
        if (Mathf.Abs(target.position.x - transform.position.x) >= float.Epsilon)
        {
            if (target.position.x > transform.position.x)
                xDir = 1;
            else
                xDir = -1;
        }
        if (Mathf.Abs(target.position.y - transform.position.y) >= float.Epsilon)
        {
            if (target.position.y > transform.position.y)
                yDir = 1;
            else
                yDir = -1;
        }

        Move(new Vector2(xDir, yDir));
    }

    void Move(Vector2 direction)
    {
        Vector2 start = transform.position;
        Vector2 end = start + direction * monsterSpeed * Time.deltaTime;
        bc2D.enabled = false;
        RaycastHit2D hit = Physics2D.Linecast(start, end, BlockingLayer);
        bc2D.enabled = true;

        if (hit.transform != null)
            return;

        Vector2 newPosition = new Vector2(end.x, end.y);
        rb2D.MovePosition(newPosition);
    }
}

