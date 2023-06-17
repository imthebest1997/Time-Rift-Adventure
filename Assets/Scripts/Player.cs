using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5;//[SerializeField] sirve para mostrar la propiedad en el Inspector 
    [SerializeField] float salto;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Rigidbody2D rb;
    BoxCollider2D boxCollider;
    private Vector2 originalSizeBC;

    //Ataque
    private float attackTimer = 0f; // Temporizador para rastrear la duración del ataque
    readonly float attackDuration = 0.15f; // Duración del ataque en segundos
    private bool isAttacking = false; // Variable de estado para controlar el estado del ataque

    //Salto
    private float jumpTimer = 0f; // Temporizador para rastrear la duración del ataque
    readonly float jumpDuration = 0.15f; // Duración del ataque en segundos
    private bool isJumpping = false; // Variable de estado para controlar el estado del ataque
    private int jumpCount = 0; // Contador de saltos

    [SerializeField] GameManager gameManager;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        originalSizeBC = boxCollider.size;
    }
    void Update()
    {
        
        //Movimiento del personaje
        float movement = Input.GetAxis("Horizontal");
        animator.SetBool("Run", Mathf.Abs(movement) > 0);// Comprobar si hay movimiento y establecer el parámetro "Run" del animador.
        transform.position += new Vector3(movement * playerSpeed * Time.deltaTime, 0f, 0f);

        // Cambiar la dirección del sprite según el movimiento
        spriteRenderer.flipX = movement < 0;


        //Salto del personaje
        if (Input.GetKeyDown(KeyCode.Space) && (jumpCount < 2 || CheckGround.isGrounded))
        {
            //Salto consecutivo
            if (jumpCount == 1)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(0.5f * salto * Vector2.up, ForceMode2D.Impulse);
            }
            //Salto Inicial
            else
            {
                rb.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
            }
          
//            animator.SetBool("Saltar", true);
            jumpCount++;
        }
        //TODO: Optional
        if (Input.GetKey(KeyCode.Space))
        {
            //animator.SetBool("Saltar", true);
            animator.SetTrigger("Saltar");
        }


        //Ataque del personaje
        if (Input.GetKeyDown(KeyCode.J) && !isAttacking)
        {
            animator.SetBool("SimpleAttack", true);
            isAttacking = true;
            attackTimer = 0f;
                
            //Modificar el tamaño del Collider para realizar mejor la colision y el ataque
            float newColliderSizeX = boxCollider.size.x * 1.35f;
            float colliderSizeY = boxCollider.size.y;

            //Redimensionar el collider solo en x
            Vector2 newColliderSize = new Vector2(newColliderSizeX, colliderSizeY);
            boxCollider.size = newColliderSize;

            //Restablecer el tamaño del Collider
            Invoke("RestoreColliderSize", 1f);
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

        //Cuando el jugador toca el suelo el contador de saltos se reinicia
        if (CheckGround.isGrounded)
        {
            animator.SetBool("Saltar", false);
            jumpCount = 0; // Reiniciar el contador de saltos cuando toque el suelo
        }

        //Verificar cuando el jugador se cae al vacio
        if(transform.position.y <= -1.19)
        {
            gameManager.VaciarVida();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isAttacking)
            {
                // El jugador ha atacado al enemigo
                Destroy(collision.gameObject);
            }
            else
            {
                // El jugador ha chocado con el enemigo sin atacar
                gameManager.ReducirVida(15f);
            }
        }

        if (collision.gameObject.CompareTag("FinalBoss"))
        {
            if (isAttacking)
            {
                gameManager.ReducirVidaFinalBoss(30f);
                if (gameManager.CurrentHealthFinalBoss == 0)
                {
                    Destroy(collision.gameObject);
                }
            }
            else
            {
                // El jugador ha chocado con el enemigo sin atacar
                gameManager.ReducirVida(15f);
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isAttacking)
            {
                // El jugador ha atacado al enemigo
                Destroy(collision.gameObject);
            }
            else
            {
                // El jugador ha chocado con el enemigo sin atacar
                gameManager.ReducirVida(15f * Time.deltaTime);
            }
        }

        if (collision.gameObject.CompareTag("FinalBoss"))
        {
/*            if (isAttacking)
            {
                gameManager.ReducirVidaFinalBoss(15f);
                if(gameManager.CurrentHealthFinalBoss == 0)
                {
                    Destroy(collision.gameObject);
                }
            }
            else
            {
*/                // El jugador ha chocado con el enemigo sin atacar
                gameManager.ReducirVida(15f * Time.deltaTime);
//            }
        }
    }

    void RestoreColliderSize()
    {
        boxCollider.size = originalSizeBC;
    }
}
