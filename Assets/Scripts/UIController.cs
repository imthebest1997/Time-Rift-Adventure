using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject winnerScreen;
    [SerializeField] Text gameScoreUI;

    public void ActivateGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void ActivateWinnerScreen()
    {
        winnerScreen.SetActive(true);
    }

    public void TryAgain()
    {
        //Volver a cargar el juego
        SceneManager.LoadScene("Game");//Nombre de la escena
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void PrintScore(float score)
    {        
        gameScoreUI.text = "Score: " + Mathf.Floor(score) + " pts";//Mostrar tiempo
    }
}
