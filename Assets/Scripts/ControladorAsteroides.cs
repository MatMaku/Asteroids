using UnityEngine;

public class ControladorAsteroides : MonoBehaviour
{
    public Asteroide AsteroidePrefab;

    public float TiempoDeAparici�n = 2.0f;
    public float CantidadDeApariciones = 1.0f;
    public float DistanciaDeAparici�n = 15.0f;
    public float Variaci�nDeTrayectoria = 15.0f;

    private void Start()
    {
        InvokeRepeating(nameof(Instanciar), this.TiempoDeAparici�n, this.TiempoDeAparici�n);
    }

    private void Instanciar()
    {
        for (int i = 0; i < this.CantidadDeApariciones; i++)
        {
            Vector3 LugarDeAparici�n = Random.insideUnitCircle.normalized * this.DistanciaDeAparici�n;
            Vector3 PuntoDeAparici�n = this.transform.position + LugarDeAparici�n;

            float Variaci�n = Random.Range(-this.Variaci�nDeTrayectoria, this.Variaci�nDeTrayectoria);
            Quaternion Rotaci�n = Quaternion.AngleAxis(Variaci�n, Vector3.forward);

            Asteroide asteroide = Instantiate(this.AsteroidePrefab, PuntoDeAparici�n, Rotaci�n);
            asteroide.Tama�o = Random.Range(asteroide.Tama�oMin, asteroide.Tama�oMax);
            if ((asteroide.Tama�o * 0.5f) > asteroide.Tama�oMin)
            {
                asteroide.Vida = 2;
                asteroide.Valor = 50;
            }
            asteroide.MoverAsteroide(Rotaci�n * -LugarDeAparici�n);
        }
    }
}

