using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 0.75f;
    [SerializeField] float fuerzaSalto = 5f;
    [SerializeField] bool esDerecha = false;
    [SerializeField] float contadorTiempo = 0;
    [SerializeField] float tiempoParaCambiar = 2;
    [SerializeField] GameManager gameManager;
    [SerializeField] bool movement = false;
    [SerializeField] bool jump = false;
    Rigidbody2D rb;

/*    GameObject nativeMan;
    SpriteRenderer spriteRendererNM;

    GameObject snake;
    SpriteRenderer spriteRendererS;
*/

    void Start()
    {
        contadorTiempo = tiempoParaCambiar;
        rb = GetComponent<Rigidbody2D>();

/*        nativeMan = GameObject.Find("NativeMan");
        spriteRendererNM = nativeMan.GetComponent<SpriteRenderer>();

        snake = GameObject.Find("Snake");
        spriteRendererS = snake.GetComponent<SpriteRenderer>();
*/        
        //Ninguna fuerza externa podra mover al enemigo
        rb.isKinematic = true;

        //Enemigos que salten
        if (jump)
        {
            rb.isKinematic = false;
            InvokeRepeating("Saltar", 2f, 3f);
        }
    }

    void Update()
    {
        if (movement)
            ApplyMovement();
    }

    //Aplica a enemigos en movimiento
    private void ApplyMovement()
    {
        if (esDerecha)
        {
            transform.position += speed * Time.deltaTime * Vector3.right;
        }
        else
        {
            transform.position += speed * Time.deltaTime * Vector3.left;
        }

        contadorTiempo -= Time.deltaTime;

        if (contadorTiempo <= 0)
        {
            esDerecha = !esDerecha;
            contadorTiempo = tiempoParaCambiar;
        }

    }

    private void Saltar()
    {
        rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
    }
}
