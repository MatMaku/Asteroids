using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float Velocidad = 5.0f;
    public float TiempoDeVida = 10.0f;
    void Update()
    {
        transform.Translate(Vector2.up * Velocidad * Time.deltaTime);
        Destroy(this.gameObject, this.TiempoDeVida);
    }
}

