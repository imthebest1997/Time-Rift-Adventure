using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
            gameManager.CrystalsOnLevel++; //Crear los diamantes
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameManager != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                gameManager.CrystalsOnLevel--;
                gameManager.UpdateScore(25);//Al tomar un cristal gano 25 puntos
                Destroy(gameObject);
            }
        }
    }

}
