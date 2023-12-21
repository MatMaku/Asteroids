using UnityEngine;

public class Asteroide : MonoBehaviour, IColisión
{
    public Sprite[] Sprites;

    public int Vida = 1;
    public int Valor = 25;
    public float Velocidad = 8.0f;
    public float TiempoDeVida = 15.0f;

    public float Tamaño = 1.0f;
    public float TamañoMin = 0.5f;
    public float TamañoMax = 1.5f;

    private Vector2 Dirección;
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        sr.sprite = Sprites[Random.Range(0, Sprites.Length)];

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.Tamaño;

        rb.mass = this.Tamaño;
    }

    public void MoverAsteroide(Vector2 Dirección)
    {
        rb.AddForce(Dirección * this.Velocidad);
        Destroy(this.gameObject, this.TiempoDeVida);
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
                if ((this.Tamaño * 0.5f) > this.TamañoMin)
                {
                    Dividir();
                    Dividir();
                }
                FindObjectOfType<ControladorJuego>().AsteroideDestruido(this);
                Destroy(this.gameObject); 
            }
            else
            {
                Vida--;
            }
        }
    }
    private void Dividir()
    {
        Vector2 Posición = this.transform.position;
        Posición += Random.insideUnitCircle * 0.5f;

        Asteroide Mitad = Instantiate(this, Posición, this.transform.rotation);
        Mitad.Tamaño = this.Tamaño * 0.5f;
        Mitad.Vida = 1;
        Mitad.MoverAsteroide(Random.insideUnitCircle.normalized * (this.Velocidad * 0.5f));
    }
}
