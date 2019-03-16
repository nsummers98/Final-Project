using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float levelStartDelay = 2f;
    public float turnDelay = 0.1f;
    public static GameManager instance = null;
    public BoardManager boardScript;
    public int playerHP = 100;
    public List<Monster> monsters;

    private int level = 0;
    private Text levelText;
    private GameObject levelImage;
    private bool doingSetup;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        monsters = new List<Monster>(1);
        boardScript = GetComponent<BoardManager>();
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        level++;
        InitGame();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void InitGame()
    {
        doingSetup = true;
        levelImage = GameObject.Find("LevelImage");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        levelText.text = "Level " + level;
        levelImage.SetActive(true);
        Invoke("HideLevelImage", levelStartDelay);
        
        monsters.Clear();
        boardScript.SetupScene(level);
    }

    private void HideLevelImage()
    {
        levelImage.SetActive(false);
        doingSetup = false;
    }

    public void GameOver()
    {
        levelText.text = "You made it " + level + " levels into the Labyrinth";
        levelImage.SetActive(true);
        enabled = false;
    }

    void Update()
    {
        if (doingSetup)
            return;
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
