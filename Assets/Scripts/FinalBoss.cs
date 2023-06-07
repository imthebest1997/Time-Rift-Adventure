using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    [SerializeField] Transform objetivo;
    [SerializeField] float speed;
    [SerializeField] bool debePerseguir;
    [SerializeField] float distancia = -3.87f;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    float distanciaAbsoluta;

    void Update()
    {
        distancia = objetivo.position.x - transform.position.x;
        distanciaAbsoluta = Mathf.Abs(distancia);

        if(distanciaAbsoluta < 5) 
            debePerseguir = true;
        else
            debePerseguir = false;

        if (debePerseguir)
        {
            animator.SetBool("isReady", true);
            transform.position = Vector2.MoveTowards(transform.position, objetivo.position, speed * Time.deltaTime);    
        }        
        if(distancia > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

}
