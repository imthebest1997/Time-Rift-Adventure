using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5;//[SerializeField] sirve para mostrar la propiedad en el Inspector 
    [SerializeField] float salto;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Rigidbody2D rb;

    //Vida de Hiroshi
    [SerializeField] Image barHealth;
    [SerializeField] float currentHealth = 100f;
    [SerializeField] float maximumHealth = 100f;

    //Ataque
    private float attackTimer = 0f; // Temporizador para rastrear la duración del ataque
    readonly float attackDuration = 0.15f; // Duración del ataque en segundos
    private bool isAttacking = false; // Variable de estado para controlar el estado del ataque

    //Salto
    private float jumpTimer = 0f; // Temporizador para rastrear la duración del ataque
    readonly float jumpDuration = 0.15f; // Duración del ataque en segundos
    private bool isJumpping = false; // Variable de estado para controlar el estado del ataque
    int numVecesSalto = 0;


    void Update()
    {
        //Movimiento del personaje
        float movement = Input.GetAxis("Horizontal");
        animator.SetBool("Run", Mathf.Abs(movement) > 0);// Comprobar si hay movimiento y establecer el parámetro "Run" del animador.
        transform.position += new Vector3(movement * playerSpeed * Time.deltaTime, 0f, 0f);

        // Cambiar la dirección del sprite según el movimiento
        spriteRenderer.flipX = movement < 0;


        //Salto del personaje
        if (Input.GetKeyDown(KeyCode.Space) && !isJumpping && CheckGround.isGrounded)
        {
            animator.SetBool("Saltar", true);
            animator.SetBool("Run", false);
            rb.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
            isJumpping = true;
            jumpTimer = 0f;

            numVecesSalto++;

            if(numVecesSalto == 2)
            {
                rb.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
                numVecesSalto = 0;
            }
        }

        //Comprobar si la animación de salto esta en proceso
        if (isJumpping)
        {
            jumpTimer += Time.deltaTime;
            if(jumpTimer >= jumpDuration) {
                animator.SetBool("Saltar", false);
                isJumpping = false;            
            }
        }


        //Ataque del personaje
        if (Input.GetKeyDown(KeyCode.J) && !isAttacking)
        {
            animator.SetBool("SimpleAttack", true);
            isAttacking = true;
            attackTimer = 0f;
        }

        //Comprobar si la animación de ataque esta en proceso
        if (isAttacking)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackDuration)
            {
                // Terminar el ataque
                animator.SetBool("SimpleAttack", false);
                isAttacking = false;
            }
        }
    }

    //TODO: Optional (Review it)
    private void OnCollisionEnter2D(Collision2D collision)
    {
/*        if(collision.gameObject.CompareTag("Suelo"))
        {
            animator.SetBool("Saltar", false);
        }
*/
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Me ha reducido vida un enemigo");
            ReducirVida(15f);
        }
    }
    
    //100% Funcional
    private void ReducirVida(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maximumHealth);
        barHealth.fillAmount = currentHealth / maximumHealth;
    }    
}
