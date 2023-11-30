using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 3; // Vida del enemigo
    public float speed = 3f; // Velocidad de movimiento del enemigo
    private Transform player; // Referencia al transform del jugador

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Encuentra el jugador por etiqueta
    }

    void Update()
    {
        // Mueve al enemigo hacia el jugador
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        // Calcula la dirección hacia el jugador
        Vector3 direction = (player.position - transform.position).normalized;

        // Mueve al enemigo en dirección al jugador
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        // El enemigo recibe daño, resta la cantidad de daño de la salud.
        health -= Mathf.RoundToInt(damage);

        if (health <= 0)
        {
            // Si la salud llega a cero o menos, destruye al enemigo.
            Destroy(gameObject);
        }
    }
}
