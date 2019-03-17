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
    }

    public void GameOver()
    {
        if (level == 1)
            levelText.text = "You made it " + level + " level into the Labyrinth";
        else
            levelText.text = "You made it " + level + " levels into the Labyrinth";
        levelImage.SetActive(true);
        enabled = false;
    }

    public void AddMonsterToList(Monster script)
    {
        monsters.Add(script);
    }
}
