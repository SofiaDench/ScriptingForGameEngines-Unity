using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    public Player player; // reference to the player object
    public Enemy enemyPrefab; // reference to the enemy prefab
    public Transform spawnPoint; // spawn point for the enemy
    public Text scoreText; // reference to the UI text object for displaying the score
    public int scorePerEnemy = 10; // score points per enemy

    private int score = 0; // current score
    private int enemiesKilled = 0; // number of enemies killed

    void Start()
    {
        SpawnEnemy(); // spawn the first enemy
        UpdateScoreText(); // update the score UI text
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation); // spawn the enemy at the spawn point
    }

    public void EnemyKilled()
    {
        score += scorePerEnemy; // add score points
        enemiesKilled++; // increment the number of enemies killed
        UpdateScoreText(); // update the score UI text

        if (score >= 100)
        {
            GameOver(); // if the player has accumulated 100 points, end the game
        }
        else
        {
            SpawnEnemy(); // otherwise, spawn a new enemy
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // update the score UI text
    }

    void GameOver()
    {
        Debug.Log("Game over!"); // print game over message to the console
        // You could also implement additional logic for game over, such as resetting the game, showing a game over screen, etc.
    }
}
