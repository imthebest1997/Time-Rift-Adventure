using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject winnerScreen;
    [SerializeField] GameObject []hearts;
    [SerializeField] Text gameTimeUI;
    public void ActivateLoseScreen()
    {
        loseScreen.SetActive(true);
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


    public void UpdateLives(int currentLives)
    {
        //3 vidas en el arreglo
        //2 vidas
        for(int i = 0; i < hearts.Length; i++)
        {
            //Si tienes una vida perdida, se va a quitar la imagen de la vida activa
            if(i >= currentLives)
            {
                hearts[i].SetActive(false);
            }
        }
    }

    public void PrintTimeElapsed(float timeElapsed)
    {
        //int minutos = (int)(timeElapsed / 60);
        //float segundosRestantes = timeElapsed % 60;
        //string tiempoFormateado = "Time: " + minutos.ToString("00") + ":" + segundosRestantes.ToString("00.000");
        
        gameTimeUI.text = "Time: " + Mathf.Floor(timeElapsed) + " segundos";//Mostrar tiempo
    }
}
