using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float turnDelay = 0.1f;
    public static GameManager instance = null;
    public BoardManager boardScript;
    public int playerHP = 100;
    public bool doorOpen = false;
    public List<Monster> monsters;

    private int level = 1;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        monsters = new List<Monster>(1);
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    void InitGame()
    {
        monsters.Clear();
        boardScript.SetupScene(level);
    }

    public void GameOver()
    {
        enabled = false;
    }

    void Update()
    {
        StartCoroutine(MoveEnemies());
    }

    public void AddMonsterToList(Monster script)
    {
        monsters.Add(script);
    }

    IEnumerator MoveEnemies()
    {
        yield return new WaitForSeconds(turnDelay);
        for (int i = 0; i < monsters.Count; i++)
            monsters[i].MoveMonster();
        yield return new WaitForSeconds(turnDelay);
    }
}
