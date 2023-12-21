using UnityEngine;

public class Destruir : MonoBehaviour
{
    public float TiempoDeVida = 2.0f;
    void Update()
    {
        Destroy(this.gameObject, this.TiempoDeVida);
    }
}
