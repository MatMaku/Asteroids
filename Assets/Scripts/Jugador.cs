using UnityEngine;

public class Jugador : MonoBehaviour
{
    //Disparo
    [SerializeField] private Transform ControladorDisparo;
    [SerializeField] private GameObject bala;

    //Movimiento
    public float Velocidad = 1.0f;
    public float Rotación = 1.0f;

    private Rigidbody2D rb;

    private bool Avanzar;
    private float Dirección;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Input de disparo
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }

        //Inputs de movimiento
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
        }

        if (Dirección != 0.0f)
        {
            rb.AddTorque(-Dirección * this.Rotación);
        }
    }
}

