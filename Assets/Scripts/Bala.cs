using UnityEngine;

public class Bala : MonoBehaviour
{
    public float Velocidad = 8.0f;
    public float TiempoDeVida = 2.5f;
    private void Update()
    {
        transform.Translate(Vector2.up * Velocidad * Time.deltaTime);
        Destroy(this.gameObject, this.TiempoDeVida);
    }
}

