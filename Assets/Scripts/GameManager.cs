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

    int crystalsOnLevel = 0;
    float score = 0;


    public int CrystalsOnLevel
    {
        get => crystalsOnLevel;
        set
        {
            crystalsOnLevel = value;
        }
    }

    //Reducir vida al jugador tras caer en una trampa o ser atacado por un enemigo
    public void ReducirVida(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maximumHealth);
        barHealth.fillAmount = currentHealth / maximumHealth;
    }

    public void UpdateScore(float points)
    {
        score += points;
        Debug.Log("Puntaje actual: " + score);
    }
}
