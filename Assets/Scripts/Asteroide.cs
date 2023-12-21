using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public Sprite[] Sprites;

    public float Velocidad = 8.0f;
    public float TiempoDeVida = 15.0f;

    public float Tamaño = 1.0f;
    public float TamañoMin = 0.5f;
    public float TamañoMax = 1.5f;

    private Vector2 Dirección;
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
        this.transform.localScale = Vector3.one * this.Tamaño;

        rb.mass = this.Tamaño;
    }
    
    public void MoverAsteroide(Vector2 Dirección)
    {
        rb.AddForce(Dirección * this.Velocidad);
        Destroy(this.gameObject, this.TiempoDeVida);
    }
}
