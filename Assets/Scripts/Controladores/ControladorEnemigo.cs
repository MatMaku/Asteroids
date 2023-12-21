using UnityEngine;

public class ControladorEnemigo : MonoBehaviour
{
    public Enemigo EnemigoPrefab;

    public float TiempoDeAparici�n = 2.0f;
    public float CantidadDeApariciones = 1.0f;
    public float DistanciaDeAparici�n = 15.0f;

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

            float Variaci�n = Random.Range(-1, 1);
            Quaternion Rotaci�n = Quaternion.AngleAxis(Variaci�n, Vector3.forward);

            Enemigo asteroide = Instantiate(this.EnemigoPrefab, PuntoDeAparici�n, Rotaci�n);
        }
    }
}
