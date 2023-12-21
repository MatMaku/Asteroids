using System.Collections;
using UnityEngine;

public class ControladorJuego : MonoBehaviour
{
    public Jugador jugador;

    public int Vidas = 3;
    public float TiempoDeReaparición = 3.0f;

    private SpriteRenderer sr;

    private void Awake()
    {
        sr = this.jugador.GetComponent<SpriteRenderer>();
    }

    public void Muerte ()
    {
        this.Vidas--;

        if (this.Vidas <= 0)
        {
            Perdiste();
        }
        else
        {
            Invoke(nameof(Reaparecer), this.TiempoDeReaparición);
        }
    }

    private void Reaparecer()
    {
        this.jugador.transform.position = Vector3.zero;
        this.jugador.gameObject.layer = LayerMask.NameToLayer("Ignorar");
        this.jugador.gameObject.SetActive(true);
        StartCoroutine(Invencibilidad());
    }

    IEnumerator Invencibilidad()
    {
        yield return new WaitForSeconds(3f);

        this.jugador.gameObject.layer = LayerMask.NameToLayer("Jugador");
    }

    private void Perdiste()
    {
        
    }
}
