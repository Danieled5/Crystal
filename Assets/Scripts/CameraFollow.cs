using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0f, 10f, -10f);
    public float raycastDistance = 10f; // Distancia m�xima del raycast

    private Renderer lastHitRenderer; // Almacena el �ltimo objeto golpeado

    void Update()
    {
        if (player != null)
        {
            // Actualiza la posici�n de la c�mara para seguir al jugador con el offset
            transform.position = player.position + offset;

            // Lanza un rayo desde la posici�n de la c�mara en la direcci�n de la vista de la c�mara
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

                    // Vuelve a activar el MeshRenderer del �ltimo objeto golpeado
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
                // Si el rayo no golpea ning�n objeto, vuelve a activar el �ltimo objeto golpeado
                if (lastHitRenderer != null)
                {
                    lastHitRenderer.enabled = true;
                    lastHitRenderer = null;
                }
            }
        }
    }
}
