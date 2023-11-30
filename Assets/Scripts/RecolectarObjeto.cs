using UnityEngine;
using TMPro;

public class RecolectarObjeto : MonoBehaviour
{
    public TextMeshProUGUI contadorTexto;
    private static int contador = 0;
    private int objetivo = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && contador < objetivo)
        {
            Recolectar();
        }
    }

    void Recolectar()
    {
        contador++;
        contadorTexto.text = $"{contador}/{objetivo}";

        // Verificar si se ha alcanzado el objetivo después de la actualización.
        if (contador == objetivo)
        {
            // Cambiar a la siguiente escena cuando se alcanza el objetivo.
            UnityEngine.SceneManagement.SceneManager.LoadScene("NombreDeTuSiguienteEscena");
        }

        // Destruir el objeto que fue tocado.
        Destroy(gameObject);
    }
}
