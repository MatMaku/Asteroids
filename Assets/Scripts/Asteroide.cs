using UnityEngine;

public class Asteroide : MonoBehaviour
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
}
