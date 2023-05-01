using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.Timeline;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public int playerScore = 0;

    [SerializeField]
    List<GameObject> enemies = new List<GameObject>();
    public int enemyCount;

    Scene currentScene;



    public void Awake()
    {
        Instance = this; 
        DontDestroyOnLoad(gameObject);

        SceneManager.activeSceneChanged += OnSceneChanged;

    }

    private void Update()
    {
        CheckIfAllEnemiesDead();
    }

    void CheckIfAllEnemiesDead()
    {
        if (currentScene.name == "Menu")
            return;

        if (currentScene.name == "InThePark")
            if(enemyCount == 0)
                SceneManager.LoadScene("Level 2");

        if (currentScene.name == "Level 2")
            if (enemyCount == 0)
                SceneManager.LoadScene("InsertNameOfSceneHereAndYouWillGoThereOK?");


    }

    //Gets called when a scene is changed. Assings the currentscene that it loaded to the currentScene variable.
    void OnSceneChanged(Scene current, Scene next)
    {
        currentScene = next;

        if (currentScene.name == "InThePark")
        {
            UpdateEnemyCount();
        }
        else if (currentScene.name == "Level 2")
        {
            UpdateEnemyCount();
        }


    }


    //Score Handling
    public void AddScore(int amount)
    {
        playerScore = playerScore + amount;
    }

    
    //Enemy Handling
    private void UpdateEnemyCount()
    {
        enemies.Clear();

        GameObject[] tempEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject item in tempEnemies)
            enemies.Add(item);

        enemyCount = enemies.Count;
    }

    public void EnemyKilled()
    {
        enemyCount--;
        playerScore = playerScore + 20;
        ScoreController.Instance.UpdateScore(playerScore);
    }

    //Player dying

    public void PlayerDied()
    {
        SceneManager.LoadScene(currentScene.name);
    }


    //Game menu functions  
    public void StartGame()
    {
        SceneManager.LoadScene("InThePark");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}


