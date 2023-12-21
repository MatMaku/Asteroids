using UnityEngine;

public class Enemigo : MonoBehaviour, IColisión
{
    private Vector2 Posición;
    private Transform Jugador;

    public int Vida = 3;
    public int Valor = 100;
    public float Velocidad = 0.5f;

    public GameObject Sonido;

    private void Update()
    {
        GameObject jugadorGameObject = GameObject.FindWithTag("Player");
        if (jugadorGameObject != null)
        {
            Jugador = jugadorGameObject.transform;
        }
        if (Jugador != null)
        {
            Posición = Jugador.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, Posición, Velocidad * Time.deltaTime);

            Quaternion rotacionDeseada = Quaternion.LookRotation(Vector3.forward, Jugador.position - transform.position);
            transform.rotation = rotacionDeseada;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DetectarColision(collision);
    }

    public void DetectarColision(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            if (Vida == 1)
            {
                Instantiate(Sonido);
                FindObjectOfType<ControladorJuego>().EnemigoDestruido(this);
                Destroy(this.gameObject);
            }
            else
            {
                Vida--;
            }
        }
    }
}
