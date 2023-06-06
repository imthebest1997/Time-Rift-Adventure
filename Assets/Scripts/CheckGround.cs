using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("Checkground esta dentro del suelo");
        isGrounded = true;   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //print("Checkground salio del suelo");
        isGrounded = false;
    }
}
