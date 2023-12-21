using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using TMPro;

public class ControladorJuego : MonoBehaviour
{
    public Jugador jugador;
    public ParticleSystem Explosi�n;

    public GameObject[] VidasPNG;
    public TextMeshProUGUI TextoPuntos;

    public GameObject MenuPausa;
    public GameObject MenuPausaPerdiste;

    public int Vidas = 3;
    public int Puntaje = 0;
    public float TiempoDeReaparici�n = 3.0f;

    public void AsteroideDestruido(Asteroide asteroide)
    {
        this.Explosi�n.transform.position = asteroide.transform.position;
        this.Explosi�n.Play();

        this.Puntaje += asteroide.Valor;
        TextoPuntos.text = Puntaje.ToString();
    }
    public void Muerte ()
    {
        this.Explosi�n.transform.position = this.jugador.transform.position;
        this.Explosi�n.Play();

        this.Vidas--;

        RestarVidas();

        if (this.Vidas == 0)
        {
            Perdiste();
        }
        else
        {
            Invoke(nameof(Reaparecer), this.TiempoDeReaparici�n);
        }
    }

    private void RestarVidas()
    {
        VidasPNG[Vidas].SetActive(false);
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
        MenuPausaPerdiste.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuPausa.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(1);
    }

    public void Resumir()
    {
        MenuPausa.SetActive(false);
        Time.timeScale = 1;
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene(0);
    }

}

