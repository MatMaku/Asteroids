using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ControladorJuego : MonoBehaviour
{
    public AudioMixer Mixer;
    public Slider SliderMusica;
    public Slider SliderEfectos;

    public Jugador jugador;
    public ParticleSystem Explosión;

    public GameObject[] VidasPNG;
    public TextMeshProUGUI TextoPuntos;

    public GameObject MenuPausa;
    public GameObject MenuPausaPerdiste;

    public int Vidas = 3;
    public float TiempoDeReaparición = 3.0f;

    private int Puntaje = 0;

    public void AsteroideDestruido(Asteroide asteroide)
    {
        this.Explosión.transform.position = asteroide.transform.position;
        this.Explosión.Play();

        this.Puntaje += asteroide.Valor;
        TextoPuntos.text = Puntaje.ToString();
        FindObjectOfType<ControlPuntaje>().ComprobarPuntos(Puntaje);
    }

    public void EnemigoDestruido(Enemigo enemigo)
    {
        this.Explosión.transform.position = enemigo.transform.position;
        this.Explosión.Play();

        this.Puntaje += enemigo.Valor;
        TextoPuntos.text = Puntaje.ToString();
        FindObjectOfType<ControlPuntaje>().ComprobarPuntos(Puntaje);
    }
    public void Muerte ()
    {
        this.Explosión.transform.position = this.jugador.transform.position;
        this.Explosión.Play();

        this.Vidas--;

        RestarVidas();

        if (this.Vidas == 0)
        {
            Perdiste();
        }
        else
        {
            Invoke(nameof(Reaparecer), this.TiempoDeReaparición);
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

    public void AjustarMusica()
    {
        float volumen = SliderMusica.value;
        Mixer.SetFloat("Musica", volumen);
    }

    public void AjustarEfectos()
    {
        float volumen1 = SliderEfectos.value;
        Mixer.SetFloat("Efectos", volumen1);
    }
}

