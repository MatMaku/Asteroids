using UnityEngine;

public class Jugador : MonoBehaviour, IColisión
{
    public Transform ControladorDisparo;
    public GameObject bala;

    public float Velocidad = 1.0f;
    public float Rotación = 1.0f;

    private Rigidbody2D rb;

    private bool Avanzar;
    private float Dirección;

    public GameObject Sonido;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Disparar();
            }
        }
        

        Avanzar = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        Dirección = Input.GetAxis("Horizontal");
    }

    private void Disparar()
    {
        Instantiate(bala, ControladorDisparo.position, ControladorDisparo.rotation);
    }

    private void FixedUpdate()
    {
        if (Avanzar)
        {
            rb.AddForce(this.transform.up * this.Velocidad);
            rb.position = new Vector2(Mathf.Clamp(rb.position.x, -8.57f, 8.57f), Mathf.Clamp(rb.position.y, -4.68f, 4.68f));
        }

        if (Dirección != 0.0f)
        {
            rb.AddTorque(-Dirección * this.Rotación);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DetectarColision(collision);
    }

    public void DetectarColision(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            Instantiate(Sonido);

            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0.0f;

            this.gameObject.SetActive(false);

            FindObjectOfType<ControladorJuego>().Muerte();
        }
    }
}

