using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] AudioClip clip;
    [SerializeField] AudioController audioController;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameManager != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                audioController.PlaySfx(clip);
                gameManager.UpdateScore(25);//Al tomar un cristal gano 25 puntos
                Destroy(gameObject);
            }
        }
    }

}
