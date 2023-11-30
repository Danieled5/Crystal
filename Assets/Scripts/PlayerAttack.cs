using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackDamage = 1f; // Daño del ataque
    private Vector3 lastDirection;  // Almacena la última dirección pulsada

    void Update()
    {
        // Actualiza la última dirección pulsada
        UpdateLastDirection();

        if (Input.GetButtonDown("Fire1")) // Puedes cambiar "Fire1" según tu configuración de entrada.
        {
            Attack();
        }
    }

    void UpdateLastDirection()
    {
        // Actualiza la dirección basada en las teclas de entrada
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        lastDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Asegura que la dirección no sea cero para evitar problemas en la normalización
        if (lastDirection.sqrMagnitude == 0f)
        {
            lastDirection = transform.forward; // Si la dirección es cero, utiliza la dirección hacia adelante del jugador
        }
    }

    void Attack()
    {
        // Raycast en la última dirección pulsada
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
