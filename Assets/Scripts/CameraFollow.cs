using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0f, 10f, -10f);
    public float raycastDistance = 10f; // Distancia máxima del raycast

    private Renderer lastHitRenderer; // Almacena el último objeto golpeado

    void Update()
    {
        if (player != null)
        {
            // Actualiza la posición de la cámara para seguir al jugador con el offset
            transform.position = player.position + offset;

            // Lanza un rayo desde la posición de la cámara en la dirección de la vista de la cámara
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            // Visualiza el rayo en la escena
            Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red);

            // Comprueba si el rayo golpea un objeto
            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                // Desactiva temporalmente el MeshRenderer del objeto golpeado
                Renderer hitRenderer = hit.collider.GetComponent<Renderer>();
                if (hitRenderer != null && hitRenderer != lastHitRenderer)
                {
                    hitRenderer.enabled = false;

                    // Vuelve a activar el MeshRenderer del último objeto golpeado
                    if (lastHitRenderer != null)
                    {
                        lastHitRenderer.enabled = true;
                    }

                    // Almacena el nuevo objeto golpeado
                    lastHitRenderer = hitRenderer;
                }
            }
            else
            {
                // Si el rayo no golpea ningún objeto, vuelve a activar el último objeto golpeado
                if (lastHitRenderer != null)
                {
                    lastHitRenderer.enabled = true;
                    lastHitRenderer = null;
                }
            }
        }
    }
}
