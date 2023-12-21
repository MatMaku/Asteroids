using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Salir()
    {
        Application.Quit();
    }
}
