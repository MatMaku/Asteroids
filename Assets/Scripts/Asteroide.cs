using UnityEngine;

public class Asteroide : MonoBehaviour, IColisi�n
{
    public Sprite[] Sprites;

    public float Velocidad = 8.0f;
    public float TiempoDeVida = 15.0f;

    public float Tama�o = 1.0f;
    public float Tama�oMin = 0.5f;
    public float Tama�oMax = 1.5f;

    private Vector2 Direcci�n;
    private SpriteRenderer sp;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        sp.sprite = Sprites[Random.Range(0, Sprites.Length)];

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.Tama�o;

        rb.mass = this.Tama�o;
    }

    public void MoverAsteroide(Vector2 Direcci�n)
    {
        rb.AddForce(Direcci�n * this.Velocidad);
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
            if ((this.Tama�o * 0.5f) > this.Tama�oMin)
            {
                Dividir();
                Dividir();
            }

            Destroy(this.gameObject);
        }
    }
    private void Dividir()
    {
        Vector2 Posici�n = this.transform.position;
        Posici�n += Random.insideUnitCircle * 0.5f;

        Asteroide Mitad = Instantiate(this, Posici�n, this.transform.rotation);
        Mitad.Tama�o = this.Tama�o * 0.5f;
        Mitad.MoverAsteroide(Random.insideUnitCircle.normalized);
    }
}
