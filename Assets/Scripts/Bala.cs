using UnityEngine;

public class Bala : MonoBehaviour, IColisión
{
    public float Velocidad = 8.0f;
    public float TiempoDeVida = 2.5f;

    private void Update()
    {
        transform.Translate(Vector2.up * Velocidad * Time.deltaTime);
        Destroy(this.gameObject, this.TiempoDeVida);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DetectarColision(collision);
    }

    public void DetectarColision(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            Destroy(this.gameObject);
        }
    }
}

