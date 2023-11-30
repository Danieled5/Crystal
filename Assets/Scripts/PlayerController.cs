using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Obtén la referencia al objeto padre
            Transform parentTransform = transform.parent;

            // Destruye el objeto actual
            Destroy(gameObject);

            if (parentTransform != null)
            {
                // Destruye el objeto padre si existe
                Destroy(parentTransform.gameObject);
            }
        }
    }
}
