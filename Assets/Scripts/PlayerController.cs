using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    private CharacterController controller;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");
        /*Vector3 movimiento = new Vector3(
            movX,
            0f,
            movZ
        );*/
        Vector3 movimiento = transform.forward * movZ +
            transform.right * movX;

        if (movimiento == Vector3.zero)
        {
            // No hay movimiento
            animator.SetBool("IsWalking", false);
        }
        else
        {
            //  Si hay movimiento
            animator.SetBool("IsWalking", true);
        }

        controller.Move(movimiento * Time.deltaTime * Speed);

        Quaternion rotation =
            Quaternion.LookRotation(movimiento.normalized);

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            rotation,
            30f * Time.deltaTime
        );

    }
}
