using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageObject : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            gameManager.ReducirVida(20);
            Debug.Log("Player Damaged");
        }
    }
}
