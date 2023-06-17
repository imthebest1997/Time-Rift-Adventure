using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject winnerScreen;
    [SerializeField] GameObject menuPauseScreen;

    [SerializeField] Text gameScoreUI;

    [SerializeField] AudioController audioController;
    [SerializeField] AudioClip audioClipGameOver;
    private bool pausedGame = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausedGame)
                ResumeGame();
            else
                ActivatePauseMenu();                   
        }
    }

    public void ActivateGameOverScreen()
    {
        audioController.musicSource.Stop();
        audioController.PlaySfx(audioClipGameOver);
        gameOverScreen.SetActive(true);
    }

    public void ActivateWinnerScreen()
    {
        winnerScreen.SetActive(true);
    }

    public void TryAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void PrintScore(float score)
    {        
        gameScoreUI.text = "Score: " + Mathf.Floor(score) + " pts";//Mostrar tiempo
    }

    public void ActivatePauseMenu()
    {
        pausedGame = true;
        Time.timeScale = 0f;
        menuPauseScreen.SetActive(true);
    }        

    public void ResumeGame()
    {
        pausedGame = false;
        Time.timeScale = 1f;
        menuPauseScreen.SetActive(false);
    }

    public void ActivateHomeScreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        if (UnityEditor.EditorApplication.isPlaying)
            UnityEditor.EditorApplication.isPlaying = false;
        else
            Application.Quit();
    }
}
