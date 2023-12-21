using UnityEngine;

public class ControladorEnemigo : MonoBehaviour
{
    public Enemigo EnemigoPrefab;

    public float TiempoDeAparición = 2.0f;
    public float CantidadDeApariciones = 1.0f;
    public float DistanciaDeAparición = 15.0f;

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

            float Variación = Random.Range(-1, 1);
            Quaternion Rotación = Quaternion.AngleAxis(Variación, Vector3.forward);

            Enemigo asteroide = Instantiate(this.EnemigoPrefab, PuntoDeAparición, Rotación);
        }
    }
}
