using System.Collections;
using UnityEngine;

public class ControladorJuego : MonoBehaviour
{
    public Jugador jugador;
    public ParticleSystem Explosi�n;

    public int Vidas = 3;
    public int Puntuaci�n = 0;
    public float TiempoDeReaparici�n = 3.0f;

    public void AsteroideDestruido(Asteroide asteroide)
    {
        this.Explosi�n.transform.position = asteroide.transform.position;
        this.Explosi�n.Play();
    }
    public void Muerte ()
    {
        this.Explosi�n.transform.position = this.jugador.transform.position;
        this.Explosi�n.Play();

        this.Vidas--;

        if (this.Vidas <= 0)
        {
            Perdiste();
        }
        else
        {
            Invoke(nameof(Reaparecer), this.TiempoDeReaparici�n);
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
