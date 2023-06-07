using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //Vida de Hiroshi
    [SerializeField] Image barHealth;
    [SerializeField] float currentHealth = 100f;
    [SerializeField] float maximumHealth = 100f;
    [SerializeField] UIController uiController;

    float score = 0;

    //Reducir vida al jugador tras caer en una trampa o ser atacado por un enemigo
    public void ReducirVida(float amount)
    {
/*        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maximumHealth);//Asegurar que la vida actual este dentro de los valores permitidos (0 y 100)
*/      
        CurrentHealth -= amount;
        //currentHealth = Mathf.Clamp(currentHealth, 0f, maximumHealth);//Asegurar que la vida actual este dentro de los valores permitidos (0 y 100)
        barHealth.fillAmount = CurrentHealth / maximumHealth;
    }

    public void VaciarVida()
    {
        barHealth.fillAmount = 0f;
        uiController.ActivateGameOverScreen();
    }

    public void UpdateScore(float points)
    {
        score += points;
        uiController.PrintScore(score);
    }

    public void RegenerarVida(float value)
    {
        print("Regenear vida");
        CurrentHealth += value;
        barHealth.fillAmount = CurrentHealth / maximumHealth;
    }

    public float CurrentHealth
    {
        get => currentHealth;
        set
        {
            currentHealth = value;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maximumHealth);//Asegurar que la vida actual este dentro de los valores permitidos (0 y 100)
            if(currentHealth == 0)
            {
                uiController.ActivateGameOverScreen();
            }
        }
    }
}
