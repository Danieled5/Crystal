using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto que ha colisionado tiene el tag "Player".
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtén la referencia al objeto padre del jugador
            Transform parentTransform = collision.transform.parent;

            // Destruye el objeto jugador
            Destroy(collision.gameObject);

            if (parentTransform != null)
            {
                // Destruye el objeto padre del jugador si existe
                Destroy(parentTransform.gameObject);
            }
        }
    }
}
