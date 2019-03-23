using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int pointsPerHealth = 20;
    public float restartLevelDelay = 1f;
    public float playerSpeed = 7f;
    public LayerMask BlockingLayer;
    public Text healthText;
    public Text collectText;

    private Door door;
    private bool doorOpen = false;
    private BoxCollider2D bc2D;
    private Rigidbody2D rb2D;
    private Monster monster;
    private int hp;
    private int runesCollected = 0;
    private float curTime = 0;
    private float nextDamage = 0.5f;
    

    void Start()
    {
        runesCollected = 0;
        door = Door.instance;
        bc2D = gameObject.GetComponent<BoxCollider2D>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        monster = GameManager.instance.monster;
        hp = GameManager.instance.playerHP;
        healthText.text = "Health: " + hp;
        collectText.text = "Runes: " + runesCollected;
    }

    private void OnDisable()
    {
        GameManager.instance.playerHP = hp;
    }
    
    void Update()
    {
        healthText.text = "Health: " + hp;
        collectText.text = "Runes: " + runesCollected;
        CheckIfDoorOpen();
        PlayerMove();
    }

    void PlayerMove()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (vertical != 0)
            horizontal = 0;
        if (horizontal != 0 || vertical != 0)
            Move(new Vector2(horizontal,vertical));
    }

    void Move(Vector2 direction)
    {
        Vector2 start = transform.position;
        Vector2 end = start + direction * playerSpeed * Time.deltaTime;
        bc2D.enabled = false;
        RaycastHit2D hit = Physics2D.Linecast(start, end, BlockingLayer);
        bc2D.enabled = true;

        if (hit.transform != null)
            return;

        Vector3 newPosition = new Vector3(end.x, end.y, 0f);
        rb2D.MovePosition(newPosition);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Exit")
        {
            Invoke("Restart", restartLevelDelay);
            enabled = false;
        }

        else if (other.tag == "Health")
        {
            if (hp < 100)
            {
                hp += pointsPerHealth;
                if (hp > 100)
                    hp = 100;
            }
            other.gameObject.SetActive(false);
        }

        else if (other.tag == "Collect")
        {
            runesCollected += 1;
            other.gameObject.SetActive(false);
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (curTime <= 0)
            {
                hp -= monster.playerDamage;
                CheckIfGameOver();
                curTime = nextDamage;
            }
            else
                curTime -= Time.deltaTime;
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void CheckIfGameOver()
    {
        if (hp <= 0)
            GameManager.instance.GameOver();
    }

    void CheckIfDoorOpen()
    {
        if (runesCollected == 10 && !doorOpen)
        { 
            door.OpenDoor();
            doorOpen = true;
        }
    }

}
