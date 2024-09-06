using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public int spawnRate = 1;

    public bool isGameActive;
    public bool isGamePaused;

    public GameObject frog;

    public GameObject titleScreen;
    public GameObject pauseScreen;
    public GameObject gameOverScreen;
    public GameObject gameScreen;

    public TextMeshProUGUI livesText;

    // Update is called once per frame
    void Update()
    {
        if (lives == 0)
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isGameActive)
        {
            if (isGamePaused)
            {
                ResumeGame();
            }

            else
            {
                PauseGame();
            }
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        isGameActive = false;
    }

    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void UpdateLives()
    {
        if (isGameActive)
        {
            lives--;
            livesText.text = "Lives: " + lives;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        isGameActive = true;
        titleScreen.SetActive(false);
        gameScreen .SetActive(true);
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(frog);
        }
    }
}
