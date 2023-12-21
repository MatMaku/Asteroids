using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public AudioMixer Mixer;
    public Slider SliderMusica;
    public Slider SliderEfectos;

    public void Jugar()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Salir()
    {
        Application.Quit();
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
