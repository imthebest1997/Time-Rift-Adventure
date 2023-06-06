using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 0.75f;
    [SerializeField] float fuerzaSalto = 14f;
    [SerializeField] bool esDerecha = false;
    [SerializeField] float contadorTiempo = 0;
    [SerializeField] float tiempoParaCambiar = 2;
    [SerializeField] GameManager gameManager;
    [SerializeField] bool movement = false;


    GameObject nativeMan;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;


    void Start()
    {
        contadorTiempo = tiempoParaCambiar;
        rb = GetComponent<Rigidbody2D>();
        nativeMan = GameObject.Find("NativeMan");
        spriteRenderer = nativeMan.GetComponent<SpriteRenderer>();

        //Ninguna fuerza externa podra mover al enemigo
        rb.isKinematic = true;

        //Enemigos que salten
        //InvokeRepeating("Saltar",2f,3f);
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
            spriteRenderer.flipX = true;
        }
        else
        {
            transform.position += speed * Time.deltaTime * Vector3.left;
            spriteRenderer.flipX = false;
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
