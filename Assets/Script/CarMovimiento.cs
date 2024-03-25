using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarMovimiento : MonoBehaviour
{
    public float velocidadMovimiento = 10f; // Velocidad de movimiento hacia adelante
    public float velocidadGiro = 150f; // Velocidad de giro

    // Update is called once per frame
    void Update()
    {
        // Movimiento hacia adelante constante
        transform.Translate(Vector3.forward * Time.deltaTime * velocidadMovimiento);

        // Si se mantiene presionada la tecla A, girar a la izquierda
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -velocidadGiro * Time.deltaTime);
        }
        // Si se mantiene presionada la tecla D, girar a la derecha
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, velocidadGiro * Time.deltaTime);
        }
    }
}
