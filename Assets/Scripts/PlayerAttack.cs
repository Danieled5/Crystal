using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackDamage = 1f; // Da�o del ataque
    private Vector3 lastDirection;  // Almacena la �ltima direcci�n pulsada

    void Update()
    {
        // Actualiza la �ltima direcci�n pulsada
        UpdateLastDirection();

        if (Input.GetButtonDown("Fire1")) // Puedes cambiar "Fire1" seg�n tu configuraci�n de entrada.
        {
            Attack();
        }
    }

    void UpdateLastDirection()
    {
        // Actualiza la direcci�n basada en las teclas de entrada
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        lastDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Asegura que la direcci�n no sea cero para evitar problemas en la normalizaci�n
        if (lastDirection.sqrMagnitude == 0f)
        {
            lastDirection = transform.forward; // Si la direcci�n es cero, utiliza la direcci�n hacia adelante del jugador
        }
    }

    void Attack()
    {
        // Raycast en la �ltima direcci�n pulsada
        Ray ray = new Ray(transform.position, lastDirection);
        RaycastHit hit;

        // Dibuja el rayo en el editor para que sea visible
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 1f);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                // El jugador ha atacado al enemigo, resta salud al enemigo.
                hit.collider.GetComponent<EnemyController>().TakeDamage(attackDamage);
            }
        }
    }
}
