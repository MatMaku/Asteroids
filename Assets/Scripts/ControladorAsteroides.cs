using UnityEngine;

public class ControladorAsteroides : MonoBehaviour
{
    public Asteroide AsteroidePrefab;

    public float TiempoDeAparición = 2.0f;
    public float CantidadDeApariciones = 1.0f;
    public float DistanciaDeAparición = 15.0f;
    public float VariaciónDeTrayectoria = 15.0f;

    private void Start()
    {
        InvokeRepeating(nameof(Instanciar), this.TiempoDeAparición, this.TiempoDeAparición);
    }

    private void Instanciar()
    {
        for (int i = 0; i < this.CantidadDeApariciones; i++)
        {
            Vector3 LugarDeAparición = Random.insideUnitCircle.normalized * this.DistanciaDeAparición;
            Vector3 PuntoDeAparición = this.transform.position + LugarDeAparición;

            float Variación = Random.Range(-this.VariaciónDeTrayectoria, this.VariaciónDeTrayectoria);
            Quaternion Rotación = Quaternion.AngleAxis(Variación, Vector3.forward);

            Asteroide asteroide = Instantiate(this.AsteroidePrefab, PuntoDeAparición, Rotación);
            asteroide.Tamaño = Random.Range(asteroide.TamañoMin, asteroide.TamañoMax);
            if ((asteroide.Tamaño * 0.5f) > asteroide.TamañoMin)
            {
                asteroide.Vida = 2;
                asteroide.Valor = 50;
            }
            asteroide.MoverAsteroide(Rotación * -LugarDeAparición);
        }
    }
}

