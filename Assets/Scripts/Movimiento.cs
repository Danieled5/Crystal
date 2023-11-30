using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 5f;
    private Animator animator;

    void Start()
    {
        // Obtener el componente Animator adjunto al objeto
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Obtener la entrada del teclado
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcular el vector de movimiento
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical) * velocidad * Time.deltaTime;

        // Aplicar el movimiento al objeto
        transform.Translate(movimiento, Space.World);

        // Activar la animación de caminar si hay entrada de movimiento con las teclas 'a' o 'd' o 'w' o 's'
        if ((movimientoHorizontal != 0f || movimientoVertical != 0f) && !Input.GetKey("s"))
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        // Hacer flip del sprite según la dirección del movimiento
        if (movimientoHorizontal > 0)
        {
            // Si nos movemos a la derecha, mantener la escala original
            transform.localScale = new Vector3(0.2672039f, 0.2672039f, 0.2672039f);
        }
        else if (movimientoHorizontal < 0)
        {
            // Si nos movemos a la izquierda, hacer flip en la dirección x
            transform.localScale = new Vector3(-0.2672039f, 0.2672039f, 0.2672039f);
        }

        // Activar la animación de front al presionar la tecla "s" o "w"
        if (movimientoVertical != 0f)
        {
            animator.SetBool("IsFront", true);
        }
        else
        {
            animator.SetBool("IsFront", false);
        }
    }
}
