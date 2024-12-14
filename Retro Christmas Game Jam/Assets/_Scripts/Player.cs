using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private IInteractable focus;
    private Vector2 movementInput;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        rb.linearVelocity = new Vector2(movementInput.x * speed, movementInput.y * speed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        IInteractable interactable = collision.gameObject.GetComponent<IInteractable>();

        if (interactable != null)
        {
            focus = interactable;

            if (Input.GetKeyDown(KeyCode.E))
            {
                focus.Interact();
            }
        }
    }
}
