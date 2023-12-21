using System.Collections;
using UnityEngine;

public class ControladorJuego : MonoBehaviour
{
    public Jugador jugador;
    public ParticleSystem Explosión;

    public int Vidas = 3;
    public int Puntuación = 0;
    public float TiempoDeReaparición = 3.0f;

    public void AsteroideDestruido(Asteroide asteroide)
    {
        this.Explosión.transform.position = asteroide.transform.position;
        this.Explosión.Play();
    }
    public void Muerte ()
    {
        this.Explosión.transform.position = this.jugador.transform.position;
        this.Explosión.Play();

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
