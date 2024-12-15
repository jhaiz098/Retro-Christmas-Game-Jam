using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float detectRange;
    [SerializeField] private LayerMask detectionMask;
    private IInteractable focusedInteractable;
    private GameObject focusedObject;
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

        Collider2D[] detector = Physics2D.OverlapCircleAll (transform.position, detectRange, detectionMask);

        if (detector != null)
        {
            Collider2D closestCollider = null;
            float closestDistance = Mathf.Infinity;

            foreach(Collider2D col in detector)
            {
                float distance = Vector2.Distance(transform.position, col.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestCollider = col;
                }
            }

            if (closestCollider != null)
            {
                focusedObject = closestCollider.gameObject;
                focusedInteractable = closestCollider.GetComponent<IInteractable>();
            }
            else
            {
                focusedObject = null;
            }
        }
        else
        {
            focusedObject = null;
        }

        if (focusedObject != null)
        {
            Debug.DrawLine(transform.position, focusedObject.transform.position);
            if (Input.GetKeyDown(KeyCode.E))
            {
                focusedInteractable.Interact();
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}
