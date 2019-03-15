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
        GameManager.instance.AddMonsterToList(this);
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    

    public void MoveMonster()
    {
        int xDir = 0;
        int yDir = 0;

        if (Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon)
            yDir = target.position.y > transform.position.y ? -1 : -1;
        else
            xDir = target.position.x > transform.position.x ? 1 : -1;

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

        Vector3 newPosition = new Vector3(end.x, end.y, 0f);
        rb2D.MovePosition(newPosition);
    }
}
