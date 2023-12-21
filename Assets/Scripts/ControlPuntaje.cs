using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlPuntaje : MonoBehaviour
{
    public static ControlPuntaje Instance;

    public TextMeshProUGUI TextoPuntosMax;

    private int PuntajeMax;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        PuntajeMax = PlayerPrefs.GetInt("PuntajeMaximo");
    }

    public void ComprobarPuntos(int Puntos)
    {
        if (Puntos > PuntajeMax)
        {
            PuntajeMax = Puntos;
            PlayerPrefs.SetInt("PuntajeMaximo", PuntajeMax);
        }

        TextoPuntosMax.text = PuntajeMax.ToString();
    }
}
