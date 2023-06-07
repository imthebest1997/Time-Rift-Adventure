using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] float value;
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameManager != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                gameManager.RegenerarVida(value);//Al tomar un cristal gano 25 puntos
                Destroy(gameObject);
            }
        }
    }

}
